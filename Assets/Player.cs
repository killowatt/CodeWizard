using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    float speed = 14.0f;
    float smoothing = 0.05f;

    public bool grounded;
    public bool flipped = false;


    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        //float groundRad = 0.2f;

        //grounded = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, groundLayer).collider;
        grounded = Physics2D.OverlapBox(transform.position + Vector3.down, new Vector2(0.75f, 0.05f), 0.0f, groundLayer);
        //Debug.DrawRay(transform.position, Vector2.down * 1.05f);
        // BORROWED CODE ##################################
        //bool wasGrounded = grounded;
        //RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * 1.0f, Vector2.down, 0.001f);
        //if (hit.collider != null)
        //{
        //    grounded = true;
        //}
        //else
        //    grounded = false;
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
        if (horizontalInput > 0.0f && flipped)
        {
            transform.localScale = transform.localScale * new Vector2(-1.0f, 1.0f);
            flipped = false;
        }
        else if (horizontalInput < 0.0f && !flipped)
        {
            transform.localScale = transform.localScale * new Vector2(-1.0f, 1.0f);
            flipped = true;
        }

        Vector2 velo = Vector2.zero;

        Vector2 targetVelocity =
            new Vector2(horizontalInput * speed,
            rb.velocity.y);

        rb.velocity = Vector2.SmoothDamp(rb.velocity,
            targetVelocity, ref velo, smoothing);
        //rb.AddForce(new Vector2(horizontalInput, 0.0f))

        // Jump
        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            grounded = false;
            rb.AddForce(new Vector2(0, 1000.0f));
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
