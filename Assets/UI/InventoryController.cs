using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject parent; //parent object of canvas
    public GameObject child; //canvas containing inventory menu

    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject;
        child = transform.GetChild(0).gameObject;
        
        child.SetActive(false);//inventory is turned off by default
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            child.SetActive(!child.activeSelf); //toggles the canvas when "I" is pressed
        }

    }

    void SetWindow()
    {

    }
}
