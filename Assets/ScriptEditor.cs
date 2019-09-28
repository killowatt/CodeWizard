using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEditor : MonoBehaviour
{

    public string stringToEdit = "Hello World\nI've got 2 lines...";

    void OnGUI()
    {
        TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
        
        // Make a multiline text area that modifies stringToEdit.
        // Make a multiline text area that modifies stringToEdit.
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Tab.ToString())))
        {
            stringToEdit= stringToEdit.Insert(editor.selectIndex, "\t");
        }
        stringToEdit = GUI.TextArea(new Rect(10, 10, 200, 100), stringToEdit, 200);


        //Debug.Log(editor.selectIndex);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
