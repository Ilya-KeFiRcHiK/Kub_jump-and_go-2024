using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    public float speed;
    Rigidbody2D rb;

    public float jumpForce;

    public Transform groundCheck;
    bool isGrounded = false;
    public float groundDistance;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 moving = new Vector2(moveHorizontal * speed, rb.velocity.y);

        rb.velocity = moving;

        if (moveHorizontal > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
