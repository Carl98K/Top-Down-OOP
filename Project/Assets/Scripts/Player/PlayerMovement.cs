using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Animator anim;

    [Header("Movement Attributes")]
    [SerializeField] private float moveSpeed; 
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashlength = 0.5f, dashCoolDown = 1f;

    private Vector2 moveDirection;
    private bool isFacingRight = true;
    private bool isMoving = false;
    private float activeMoveSpeed;
    private float dashCounter, dashCoolCounter;
    
    private void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        ProcessInputs();
        Dash();

        if(moveDirection != Vector2.zero)
            isMoving = true;
        else if(moveDirection == Vector2.zero)
            isMoving = false;

        anim.SetBool("isMoving", isMoving);
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        /*if(moveX < 0 && isFacingRight)
            Flip();
        else if(moveX > 0 && !isFacingRight)
            Flip();*/
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * activeMoveSpeed, moveDirection.y * activeMoveSpeed);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    private void Dash()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashlength;
                tr.emitting = true;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.fixedDeltaTime;
    
            if(dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if(dashCoolCounter > 0)
        {
            tr.emitting = false;
            dashCoolCounter -= Time.fixedDeltaTime;
        }
    }
}
