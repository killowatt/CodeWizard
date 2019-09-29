using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //public BoxCollider2D InteractionArea;

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

        Door d = GetComponentInChildren<Door>();

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

        Door d = GetComponentInChildren<Door>();

        d.CurrentScript = editor.stringToEdit;

        d.Environment.DoString(d.CurrentScript, null, d.name);
        bool so = d.Environment.Call(d.Environment.Globals["ShouldOpen"]).Boolean;

        if (so)
        {
            d.Open();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            Debug.Log("Open!");
        }
    }
}
