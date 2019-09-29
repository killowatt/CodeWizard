using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SpellBookController : MonoBehaviour
{
    GameObject Spellbook;
    GameObject[] Slots;
    List<string> Spells;

    // Start is called before the first frame update
    void Start()
    {
        Spellbook = this.gameObject;
        Slots = new GameObject[12];
        Spells = new List<string>();
        string path = Application.dataPath + "/UI/Spells/";
        Debug.Log(path);
        string[] filenames = Directory.GetFiles(path, "*.txt");
        Debug.Log(filenames.ToString());
        
        for (int i = 0; i<filenames.Length; i++)
        {
            string spellname = filenames[i];
            Debug.Log(spellname);
            spellname = spellname.Replace(path, "");
            spellname = spellname.Replace(".txt", "");
            
            GameObject temp = Spellbook.transform.GetChild(i).gameObject;
            GameObject text = temp.transform.GetChild(1).gameObject;
            text.GetComponent<UnityEngine.UI.Text>().text = spellname;
            Spells.Add(spellname);

        }
            
    }

    public void addSpell(string spellname)
    {
        GameObject temp = Spellbook.transform.GetChild(Spells.Count).gameObject;
        GameObject text = temp.transform.GetChild(1).gameObject;
        text.GetComponent<UnityEngine.UI.Text>().text = spellname;
        Spells.Add(spellname);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
