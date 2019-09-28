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
        Door d = GetComponentInChildren<Door>();
        d.ToggleOpened();

        Debug.Log("You interacted!!");
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
