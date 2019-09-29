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

    public static Vector3 GUIScale()
    {
        float normalWidth = 1600;
        float normalHeight = 900;
        return new Vector3(Screen.width / normalWidth, Screen.height / normalHeight, 1);
    }

    public static Matrix4x4 GetGUIMatrix()
    {
        return Matrix4x4.TRS(Vector3.zero, Quaternion.identity, GUIScale());
    }

    void OnGUI()
    {
        GUI.matrix = GetGUIMatrix();

        TextEditor editor = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);

        // Make a multiline text area that modifies stringToEdit.
        if (editable && Event.current.Equals(Event.KeyboardEvent(KeyCode.Tab.ToString())))
        {
            stringToEdit = stringToEdit.Insert(editor.selectIndex, "\t");
        }
        stringToEdit = GUI.TextArea(new Rect(1175, 190, 400, 700), stringToEdit, 500);
        fileName = GUI.TextField(new Rect(1175, 145, 200, 40), fileName, 500);
        
    }

    public void SaveSpell( GameObject spellbook)
    {


        if (!editable)
            return;
        //get path of file
        string path = Application.dataPath + "/UI/Spells/" + fileName + ".txt";
        File.WriteAllText(path, stringToEdit);
        if (!File.Exists(path))
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
