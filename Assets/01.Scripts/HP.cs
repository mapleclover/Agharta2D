using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    int hp=3;
    int currentHP;
    int atk;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this, 1.0f);
            
        }
    }
}
