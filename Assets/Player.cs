using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(horizontal * 5.0f, 0.0f));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
