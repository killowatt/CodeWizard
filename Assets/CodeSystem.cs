using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
public class CodeSystem : MonoBehaviour
{
    public Script Environment;
    [Multiline]
    public string DefaultScript;
    public string CurrentScript;
    public string ReturningFunction;

    public bool valid = true;

    public CodeSystem[] InputSystems;

    // Start is called before the first frame update
    public virtual void Start()
    {

            Environment = new Script(CoreModules.None);

        CurrentScript = DefaultScript;
        //InvokeRepeating("RunCode", 1.0f, 1.0f);
    }
    public void DoStuff()
    {
        try
        {
            DynValue d = Environment.DoString(CurrentScript, null, name);

            Debug.Log(d.Number);
        }
        catch (ScriptRuntimeException e)
        {
            Debug.LogError("Script runtime err " + e.DecoratedMessage);
            valid = false;
        }
        catch (SyntaxErrorException e)
        {
            Debug.LogError("Script syntax err " + e.DecoratedMessage);
            valid = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunCode()
    {
        if (!valid) return;

        Environment.Call(Environment.Globals[ReturningFunction]);
    }
}
