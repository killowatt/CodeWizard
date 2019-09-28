using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject parent; //parent object of canvas
    public GameObject canvas; //canvas containing inventory menu

    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject;
        canvas = transform.GetChild(0).gameObject;
        
        canvas.SetActive(false);//inventory is turned off by default
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            canvas.SetActive(!canvas.activeSelf); //toggles the canvas when "I" is pressed
        }

    }


}
