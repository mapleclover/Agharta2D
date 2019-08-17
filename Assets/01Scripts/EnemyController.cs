using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum Attack { Move, Down, Scratch, Rush }
    private int[] skill= new int[] { 45,20,20,10 };

    public GameObject Player;
    private Rigidbody2D Rigidbody;
    CameraShake Camera;

    private Vector3 Player_pos;
    private Vector3 Enemy_pos;
    private Vector3 dash_pos;
    private Vector3 down_pos;
    private Vector3 rush_pos;
    private Vector3 scratch_pos;
 
    public float speed = 3;
    private float rushSpeed = 1000;
    public int HP = 5;

    private int rushCount;
    private int downCount;
    private int scratchCount;
    private int arrowCount;

    private bool chasing = true;
    private bool dash = false;
    private bool down = false;
    private bool scratch = false;
    private bool rush = false;

    public GameObject bullet;
    public Transform pos; //총알의 생성위치


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
        
    }
    IEnumerator CheckAttack()
    {
        int num = RandomAttack(skill);
        Debug.Log("0");
        while (HP>0)
        {
            if (num==0)
            {
                Debug.Log("dash");
                if (chasing)
                    Move();
                if (dash)
                    Dash();
            }
            else if (num == 1)
            {
                Debug.Log("down");
                Down();
            }
            else if (num == 2)
            {
                Debug.Log("scratch");
                Scratch();
            }
            else if (num == 3)
            {
                Debug.Log("rush");
                Rush();
                Camera.VibrateForTime(0.1f);
            }

            yield return new WaitForSeconds(0.1f);

        }
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



    IEnumerator ChaseDelay()
    {
        dash_pos = Player_pos;
        yield return new WaitForSeconds(1f);
        dash = true;
    }

    IEnumerator DashDelay()
    {
        yield return new WaitForSeconds(2f);
        chasing = true;
    }

    IEnumerator DownDelay()
    {

        down = true;
        down_pos = Player_pos;
        
        yield return new WaitForSeconds(1f);
        downCount++;
        if (down_pos.x < Enemy_pos.x)
        {
            Rigidbody.AddForce(new Vector3(-400, 400, 0));

        }
        else if (down_pos.x > Enemy_pos.x)
        {
            Rigidbody.AddForce(new Vector3(400, 400, 0));
        }
       
        down = false;

    }

    IEnumerator RushDelay()
    {
        rush = true;
        rush_pos = Player_pos;
        yield return new WaitForSeconds(1f);

        rushCount++;
        transform.position = Vector3.MoveTowards(transform.position, Player_pos, Time.deltaTime * rushSpeed);
        Debug.Log("2");
        rush = false;
        
    }

    IEnumerator ScratchDelay()
    {
        scratch = true;
        scratch_pos = Player_pos;
        yield return new WaitForSeconds(1f);

        scratchCount++;

        transform.position = Vector3.MoveTowards(transform.position, Player_pos, Time.deltaTime * rushSpeed);
        Debug.Log("1");
        scratch = false;
    }

    void Move()
    {
        if (Enemy_pos.x - Player_pos.x <= 3 && Enemy_pos.x - Player_pos.x >= -3)
        {
            chasing = false;
            StartCoroutine("ChaseDelay");
        }
        else
        {
            if (Player_pos.x < Enemy_pos.x)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (Player_pos.x > Enemy_pos.x)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }

    void Dash()
    {
        speed = 30;


        if (dash_pos.x < Enemy_pos.x)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (dash_pos.x > Enemy_pos.x)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }


        if (Enemy_pos.x - dash_pos.x <= 2 && Enemy_pos.x - dash_pos.x >= -2)
        {
            speed = 2;
            dash = false;
            StartCoroutine("DashDelay");
        }

    }

    void Down()
    {
        if (Rigidbody.velocity.y == 0)
        {
            
            if (down==false)
            {
                if(downCount==0)
                 StartCoroutine("DownDelay");
                else
                    return;
            }
        }
    }

    void Scratch()
    {
        scratch_pos = Player_pos;
        if (-3 < scratch_pos.x - Enemy_pos.x && scratch_pos.x - Enemy_pos.x < 3)
        {

            if (scratch == false)
            {
                if (scratchCount == 0)
                    StartCoroutine("ScratchDelay");
                else
                    return;
            }
        }
    }

    void Rush()
    {
        
        if (Rigidbody.velocity.y == 0)
        {
            if (rush==false)
            {
                if (rushCount == 0)
                {
                    StartCoroutine("RushDelay");
                    Camera.VibrateForTime(3f);
                }
            }
        }   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        
        direction = direction.normalized * 100;

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
   
            Debug.Log("1");
        }
    }

    void EnemyDamaged(GameObject gameObject)
    {
        HP -= 1;

        if (HP <= 0)//피격후 사망시 즉시사망
        {
            Rigidbody.velocity = new Vector2(0, 0);
            return;
        }
    }

    private void Update()
    {
        Player_pos = Player.transform.position;
        Enemy_pos = this.transform.position;

        //EnemyAttack();
        
        //if (chasing)
        //    Move();
        //if (dash)
        //    Dash();
        //Down();

        Rush();
        Camera.VibrateForTime(0.1f);
    }



}