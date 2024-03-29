using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float horizontalInput = 1f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float speedMultiplier = 40f;
    [SerializeField] private float jumpHeight = 2f;
    private float gravity = -50f;
    private bool isGrounded = false;
    private Vector3 velocity;

  
    private CharacterController characterController;
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        //Adding gravity to velocity
        
        transform.forward = new Vector3(horizontalInput, 0f, Mathf.Abs(horizontalInput) -1 );


        isGrounded = Physics.CheckSphere(transform.position, 0.6f,groundLayer, QueryTriggerInteraction.Ignore);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0; 
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        //Using component move with velocity
        //characterController.Move(velocity * Time.deltaTime);
        //Jumping
        //Input.GetKeyDown(KeyCode.Space);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }



        characterController.Move(new Vector3(horizontalInput, 0, 0) * speedMultiplier *  Time.deltaTime);
        characterController.Move(velocity * Time.deltaTime);
    }
}
