using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderController : MonoBehaviour
{
    public GameObject ladderPrefab;
    public float speed = 6;
    public bool isClimb = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.UpArrow))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            isClimb = true;
        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.DownArrow))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            isClimb = true;
        }
        else if (isClimb && Input.GetKey(KeyCode.Space) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            isClimb = false;
        }
        else if (other.tag != "Player")
        {
            isClimb = false;
        }
        else
        {
            if (isClimb)
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            else if (!isClimb)
            {

            }

        }
    }
}
