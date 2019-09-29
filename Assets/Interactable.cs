using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //public BoxCollider2D InteractionArea;
    //public GameObject ToManipulate;

    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Interact()
    {
        GameObject ui = GameObject.Find("UI").transform.GetChild(0).gameObject; // epic
        ui.SetActive(!ui.activeSelf);

        GameObject edo = ui.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        ScriptEditor editor = edo.GetComponent<ScriptEditor>();

        editor.calback = this;

        CodeSystem d = GetComponentInChildren<CodeSystem>();

        editor.editable = !d.DoNotEdit;

        if (!ui.activeSelf)
            d.CurrentScript = editor.stringToEdit;
        else
            editor.stringToEdit = d.CurrentScript;


        Debug.Log("Interact/UI");
    }
    public void MakeThingDo()
    {
        GameObject ui = GameObject.Find("UI").transform.GetChild(0).gameObject; // epic
        GameObject edo = ui.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        ScriptEditor editor = edo.GetComponent<ScriptEditor>();

        CodeSystem d = GetComponentInChildren<CodeSystem>();
        //CodeSystem d = ToManipulate.GetComponent<CodeSystem>();
        //Door d = GetComponentInChildren<Door>();

        d.CurrentScript = editor.stringToEdit;

        //d.Environment.DoString(d.CurrentScript, null, d.name);
        d.Reeval();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            //Debug.Log("Open!");
        }
    }
}
