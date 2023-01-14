using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Movement: MonoBehaviour
{
    Rigidbody rb;
    bool canJump;
    KeyCode space = KeyCode.Space;
    bool onTheGround;
    float horizontal;
    float vertical;
    Vector3 moveDirection;

    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airStabilizator;
    public float height;
    public LayerMask terrain;
    public Transform orientation;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canJump = true;
    }

    private void Update()
    {
        onTheGround = Physics.Raycast(transform.position, Vector3.down, height * 0.5f + 0.3f, terrain);

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(space) && canJump && onTheGround)
        {
            canJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        limitV();

        if (onTheGround)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        moveDirection = orientation.forward * vertical + orientation.right * horizontal;

        if (onTheGround)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!onTheGround)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airStabilizator, ForceMode.Force);
    }

    private void limitV()
    {
        Vector3 horizontalV = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (horizontalV.magnitude > moveSpeed)
        {
            Vector3 limitedVel = horizontalV.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        canJump = true;
    }
}