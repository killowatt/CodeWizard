using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;

[MoonSharpUserData]
class CodeDoor
{

    void Open()
    {

    }
    void Close()
    {

    }
}
public class Door : CodeSystem
{
    public BoxCollider2D Collider;
    public CircleCollider2D UsableArea;

    public Vector2 ClosedPosition;
    public Vector2 OpenedPosition;

    public bool IsOpened = false;

    public GameObject f;

    public void Open()
    {
        IsOpened = true;
    }
    public void Close()
    {
        IsOpened = false;

    }
    public void ToggleOpened()
    {
        if (IsOpened)
            Close();
        else
            Open();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        UsableArea = GetComponent<CircleCollider2D>();


        ClosedPosition = transform.position;
        OpenedPosition = ClosedPosition + Vector2.up * 2.9f;

        AirFilter z = f.GetComponent<AirFilter>();
        Environment.Globals["ac"] = z.cd;

        DoStuff();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 DesiredPosition = ClosedPosition;
        if (IsOpened) DesiredPosition = OpenedPosition;

        Vector3 velocity = Vector3.zero;
        transform.position =
            Vector3.SmoothDamp(transform.position, DesiredPosition,
            ref velocity, 0.05f);

    }


}
