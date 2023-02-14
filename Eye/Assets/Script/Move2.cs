using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    Rigidbody2D rb;
    float movex;

    bool doublejump = false;
    bool isground = false;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (rb.velocity.y == 0)
            isground= true;
        else
            isground = false;

        if(isground)
            doublejump= true;

        if (isground && Input.GetKeyDown("c"))
            JumpAddForce();
        else if (doublejump && Input.GetKeyDown("c"))
        {
            JumpAddForce();
            doublejump=false;
        }

        movex = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(movex, rb.velocity.y);
    }

    void JumpAddForce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce);
    }
}
