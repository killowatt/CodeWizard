using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScriptEditor : MonoBehaviour
{
    public GameObject SubPanel;
    public string fileName = "New Spell";
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
        fileName = GUI.TextField(new Rect(550, 60, 75, 20), fileName, 500);



        //Debug.Log(editor.selectIndex);

    }

    public void SaveSpell()
    {
        //get path of file
        string path = Application.dataPath + "/UI/Spells/" + fileName + ".txt";
        Debug.Log(path);
        //check if file exists
        if (!File.Exists(path))
        {
            File.WriteAllText(path, stringToEdit);
        }


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
