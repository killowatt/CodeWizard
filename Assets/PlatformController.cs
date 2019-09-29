using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;

[MoonSharpUserData]
public class PlatformCode
{
    [MoonSharpHidden]
    public PlatformController Parent;
    [MoonSharpHidden]
    public GameObject A;
    [MoonSharpHidden]
    public Vector3 OgLocal;
    [MoonSharpHidden]
    public float DesiredY;

    [MoonSharpHidden]
    public void UpdatePos()
    {
        Vector3 velocity = Vector3.zero;
        A.transform.localPosition =
            Vector3.SmoothDamp(A.transform.localPosition, OgLocal + Vector3.up * DesiredY,
            ref velocity, 0.05f);
    }

    float GetY()
    {
        return DesiredY;
    }
    public void MoveUp()
    {
        if (DesiredY < Parent.UpperLimitY)
            DesiredY += 1.0f;
        //Debug.Log("MovedUpPlatform");
    }
    public void MoveDown()
    {
        if (DesiredY > Parent.LowerLimitY)
            DesiredY -= 1.0f;
    }
}
public class PlatformController : CodeSystem
{
    public float UpperLimitY;
    public float LowerLimitY;
    public float ZeroY;

    List<PlatformCode> luaPlatforms;

    public override void Reeval()
    {
        base.Reeval();

        DoStuff();
        Environment.Call(Environment.Globals[ReturningFunction]);
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        UserData.RegisterType<PlatformCode>();

        Table envTable = new Table(Environment);

        luaPlatforms = new List<PlatformCode>();

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject g = transform.GetChild(i).gameObject;
            PlatformCode c = new PlatformCode();
            luaPlatforms.Add(c);
            c.Parent = this;
            c.A = g;

            c.OgLocal = g.transform.localPosition;
            c.OgLocal.y = ZeroY;
            c.DesiredY = Mathf.Round(g.transform.localPosition.y - ZeroY);

            DynValue val = UserData.Create(c);
            envTable.Set(i + 1, val);
        }

        Environment.Globals["plats"] = envTable;

        DoStuff();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (PlatformCode c in luaPlatforms)
        {
            c.UpdatePos();
        }
    }
}
