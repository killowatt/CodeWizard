using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScriptEditor : MonoBehaviour
{
    public GameObject SubPanel;
    public string fileName = "New Spell";
    public string stringToEdit = "";

    public bool editable = true; //check for writeability to a spell

    //sry connor
    public Interactable calback;

    void OnGUI()
    {
        if (!editable)
            return;
        TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

        // Make a multiline text area that modifies stringToEdit.
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Tab.ToString())))
        {
            stringToEdit = stringToEdit.Insert(editor.selectIndex, "\t");
        }
        stringToEdit = GUI.TextArea(new Rect(550, 80, 200, 325), stringToEdit, 500);
        fileName = GUI.TextField(new Rect(550, 60, 75, 20), fileName, 500);




    }

    public void SaveSpell( GameObject spellbook)
    {


        if (!editable)
            return;
        //get path of file
        string path = Application.dataPath + "/UI/Spells/" + fileName + ".txt";

        File.WriteAllText(path, stringToEdit);

        spellbook.GetComponent<SpellBookController>().addSpell(fileName);

        if (calback)
            calback.MakeThingDo();

    }

    void clearBox()
    {
        fileName = "New Spell";
        stringToEdit = "";

    }

    public void openSpell(UnityEngine.UI.Text spellName)
    {
        Debug.Log(spellName.text);
        string path = Application.dataPath + "/UI/Spells/" + spellName.text + ".txt";

        stringToEdit = File.ReadAllText(path);
        Debug.Log(stringToEdit);
        fileName = spellName.text;
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
