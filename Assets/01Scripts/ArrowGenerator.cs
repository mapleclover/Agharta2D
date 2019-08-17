using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    GameObject player;
    public GameObject arrowPrefab;
    
    float span = 1.0f;
    float delta = 0;

    void Start()
    {
        this.player = GameObject.Find("player");
    }

    
    void Update()
    {
        Vector3 player_pos = player.transform.position;
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab) as GameObject; 
            int px = Random.Range(-2, 2);
           
            go.transform.position = new Vector3(player_pos.x + px, 6, 0);
        }
    }
}
