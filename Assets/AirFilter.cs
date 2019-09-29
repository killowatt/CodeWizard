using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;

[MoonSharpUserData]
public class AirFilterCode
{
    [MoonSharpHidden]
    AirFilter Parent;

    bool DefaultValue = false;

    public bool CheckAir()
    {
        if (!Parent.valid) return DefaultValue;

        DynValue d = Parent.Environment.Call(
            Parent.Environment.Globals[Parent.ReturningFunction]);

        if (d.Type != DataType.Boolean) return DefaultValue;
        return d.Boolean;
    }

    [MoonSharpHidden]
    public AirFilterCode(AirFilter parent)
    {
        Parent = parent;
    }
}
public class AirFilter : CodeSystem
{
    public AirFilterCode cd;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        DoStuff();

        UserData.RegisterType<AirFilterCode>();
        cd = new AirFilterCode(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
