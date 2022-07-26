using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{


    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.position);
        //3 Vector positions adding offset to player position to make the camera follow the player
        //This method also makes the camera not rotate when the player rotates
        transform.position = player.position + offset;
    }
}
