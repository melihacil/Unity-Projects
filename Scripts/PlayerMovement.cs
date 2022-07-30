using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement")]
    public float movementSpeed = 7.0f;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    public float groundDrag;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; 

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;






    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Rigidbody rb;

    Vector3 moveDirections;

    void Start()
    {
        //Getting the rigidbody and freezing the rotation 
        //To prevent falling over
        //To prevent falling over
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }

    private void FixedUpdate()
    {
        MoveFunc();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        //handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 3;
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);


        }
    }

    private void MoveFunc()
    {
        moveDirections = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
            rb.AddForce(moveDirections.normalized * movementSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirections.normalized * movementSpeed * 10f * airMultiplier, ForceMode.Force);
    }



    private void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if ( flatvel.magnitude > movementSpeed)
        {
            Vector3 limitedVelocity = flatvel.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        //Force mode impulse because of applying only once
        //Adding jump force to y axis 
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }


}
