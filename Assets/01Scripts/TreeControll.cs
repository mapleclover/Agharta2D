using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeControll : MonoBehaviour
{
    private enum Attack { Rush }
    private int[] skill = new int[] { 50 };

    public GameObject Player;
    public GameObject player;
    private Rigidbody2D Rigidbody;
    CameraShake Camera;

    private Vector3 Player_pos;
    private Vector3 Enemy_pos;
   
    public float speed = 2;

    private int arrowCount;
    private bool arrow = false;

    public GameObject bullet;
    public Transform pos; //총알의 생성위치

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    IEnumerator CheckAttack()
    {
        int num = RandomAttack(skill);
        Debug.Log("0");
       
            if (num == 0)
            {
                
            }
            else if (num == 1)
            {

            }

            yield return new WaitForSeconds(0.1f);

        
    }//공격체크

    int RandomAttack(int[] percent)
    {
        //전체에서 임의의 수를 선택한 후, 어느 부분에 있는지 확인. 그수가 어느배열요소 안에 있는지확인 >> 그수와 1째 요소 비교, 크면 뺀후 2째요소와 비교

        int total = 0;

        foreach (int elem in percent)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < percent.Length; i++)
        {
            if (randomPoint < percent[i])
            {
                return i;
            }
            else
            {
                randomPoint -= percent[i];
            }
        }
        return percent.Length - 1;
    }

    void EnemyAttack()
    {

        if (Rigidbody.velocity.y == 0)
        {
            StartCoroutine(CheckAttack());
            Debug.Log("rush");
        }
    }

    IEnumerator ArrowDelay()
    {
        arrow = true;
        
        yield return new WaitForSeconds(1f);
        Instantiate(this, this.transform.position, Quaternion.identity);
        arrowCount++;
       
       arrow = false;

    }
    void Arrow()
    {

        if (Rigidbody.velocity.y == 0)
        {
            if (arrow == false)
            {
                if (arrowCount == 0)
                {
                    StartCoroutine("arrowDelay");
                }
            }
        }
    }

 

    private void Update()
    {
        Player_pos = Player.transform.position;
        Enemy_pos = this.transform.position;

        EnemyAttack();
        //Rush();
    }



}