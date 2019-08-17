using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffinControll : MonoBehaviour
{
    private enum Attack { Rush }
    private int[] skill = new int[] { 50 };

    public GameObject Player;
    private Rigidbody2D Rigidbody;
    CameraShake Camera;

    private Vector3 Player_pos;
    private Vector3 Enemy_pos;
    private Vector3 rush_pos;

    public float speed = 2;
    private float rushSpeed = 800;
    public int HP = 5;
    private int rushCount;
    private bool rush = false;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }
    IEnumerator CheckAttack()
    {
        int num = RandomAttack(skill);
        Debug.Log("0");
        while (HP > 0)
        {
            if (num == 0)
            {
                Debug.Log("rush");
                Rush();
                Camera.VibrateForTime(0.1f);

            }
            else if (num == 1)
            {

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
    void Rush()
    {

        if (Rigidbody.velocity.y == 0)
        {
            if (rush == false)
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

        EnemyAttack();
        //Rush();
    }



}