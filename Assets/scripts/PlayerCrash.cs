using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : Singleton <PlayerCrash>
{
    public int hp = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject); //적을 파괴합니다.'
            --hp;
        }
    }
}
