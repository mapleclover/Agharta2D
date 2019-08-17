using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        }
    }
}
