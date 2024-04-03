using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    Vector2 move;
    Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.magnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
