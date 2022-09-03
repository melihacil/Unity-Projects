using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Vector3 offset;


    [SerializeField] private Transform player = null;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, 0, player.position.z) + offset, Time.deltaTime * 3); 
    }





}
