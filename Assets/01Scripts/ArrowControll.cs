using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControll : MonoBehaviour
{
    GameObject player;

    
    void Start()
    {
        this.player = GameObject.Find("player");
        
    }

    void Update()
    {
        Vector2 arrow_pos = transform.position;
        Vector2 player_pos = this.player.transform.position;

        //프레임마다 등속으로 낙하시킨다.
       
            transform.Translate(0, -0.1f, 0);

        
        //화면 밖으로 나오면 오브젝트를 소멸시킨다.
        if (transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }

        //충돌판정
        Vector2 dir = arrow_pos - player_pos;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            // 충돌하면 화살을 소멸시킨다
            Destroy(gameObject);
        }
    }
}
