using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    float speed = 14.0f;
    float smoothing = 0.05f;

    private bool grounded;

    public Transform grdchek; // pos to check ground

    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //float groundRad = 0.2f;

        // BORROWED CODE ##################################
        //bool wasGrounded = grounded;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * 1.5f, Vector2.down, 0.05f);
        if (hit.collider != null)
        {
            grounded = true;
        }
        else
            grounded = false;
            //// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        //// This can be done using layers instead but Sample Assets will not overwrite your project settings.
        //Collider2D[] colliders = Physics2D.OverlapCircleAll(grdchek.position, groundRad);
        //for (int i = 0; i < colliders.Length; i++)
        //{
        //    if (colliders[i].gameObject != gameObject)
        //    {
        //        grounded = true;
        //        //if (!wasGrounded)
        //        //    OnLandEvent.Invoke();
        //    }
        //}
        //// BORROWED CODE#####################################

        float horizontalInput = Input.GetAxis("Horizontal");


        Vector2 velo = Vector2.zero;

        Vector2 targetVelocity =
            new Vector2(horizontalInput * speed,
            rb.velocity.y);

        rb.velocity = Vector2.SmoothDamp(rb.velocity,
            targetVelocity, ref velo, smoothing);

        // Jump
        if (grounded && Input.GetKey(KeyCode.W))
        {
            grounded = false;
            rb.AddForce(new Vector2(0, 100.0f));
        }
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = 0.0f;

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    vertical = 256.0f;
        //}

        //rb.AddForce(new Vector2(horizontal * 16.0f, vertical));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
