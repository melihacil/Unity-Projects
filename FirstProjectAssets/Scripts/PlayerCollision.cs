using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement2 movement;
    //When it collides on something (ENTERING collision)
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit something");
        //Debug.Log(collision.collider.name);
        //Checking through name is not a good way in a larger game
        //Rather than doing that you can just use tags
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log(collision.collider.name);
            movement.enabled = false;
            //GetComponent<PlayerMovement2>().enabled = false;

            FindObjectOfType<GameManager>().EndGame();
        }
    }


}
