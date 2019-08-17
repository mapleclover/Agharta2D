using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = this.player.transform.position;
        //if (playerPos.y < -2.9 || (playerPos.x > -13 && playerPos.x < 5.2) )
        //{
               transform.position = new Vector3(playerPos.x, playerPos.y + 2.8f, transform.position.z);
        //}

        //else if(playerPos.y >= -2.9)
        //    transform.position = new Vector3(playerPos.x, -0.5f, transform.position.z);
    }
}