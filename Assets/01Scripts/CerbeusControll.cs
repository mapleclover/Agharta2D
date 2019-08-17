using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerbeusControll : MonoBehaviour
{
    public GameObject fire;
    private Vector3 Enemy_pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_pos = this.transform.position;
        if (Input.GetKey(KeyCode.Z))
            Instantiate(fire,Enemy_pos,transform.rotation);
    }
}
