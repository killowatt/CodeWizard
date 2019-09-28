using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEditor : MonoBehaviour
{
    public GameObject SubPanel;
    public string stringToEdit = "";

    void OnGUI()
    {
        TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

        // Make a multiline text area that modifies stringToEdit.
        // Make a multiline text area that modifies stringToEdit.
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Tab.ToString())))
        {
            stringToEdit = stringToEdit.Insert(editor.selectIndex, "\t");
        }
        stringToEdit = GUI.TextArea(new Rect(550, 80, 200, 325), stringToEdit, 500);


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
