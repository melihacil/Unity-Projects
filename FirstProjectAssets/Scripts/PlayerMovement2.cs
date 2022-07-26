using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{


    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BumBastic");
        //rb.useGravity = false;
       // rb.AddForce(0,200,500);
    }

    // Update is called once per frame
    /*
    void Update()
    {
        rb.AddForce(0, 0 , 500 * Time.deltaTime);
    }
    */
    void FixedUpdate()
    {
        //adding a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //rb.AddForce(0,0,0);
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

}
