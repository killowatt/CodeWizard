using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    public GameObject Tabs; //parent object of canvas
    public GameObject spell_editor;
    public GameObject spellbook;

    GameObject activeTab;

    // Start is called before the first frame update
    void Start()
    {
        Tabs = gameObject;
        spell_editor = transform.GetChild(0).gameObject;
        spellbook = transform.GetChild(1).gameObject;

        spell_editor.SetActive(false);
        activeTab = spellbook;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveWindow(GameObject next_active)
    {
        if(activeTab.name != next_active.name)
        {
            activeTab.SetActive(false);
            next_active.SetActive(true);
            activeTab = next_active;
        }
    }
}
