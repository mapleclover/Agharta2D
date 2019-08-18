using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mudController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
