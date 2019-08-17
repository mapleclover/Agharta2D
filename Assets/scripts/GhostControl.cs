using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{

    protected Rigidbody2D _rigidbody;

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = true;
    bool chasing = false;
    bool back = false;
    GameObject target;
    Vector3 Pos, localScale, Pos1, start_pos;
    Vector3 targetPos;
    bool MovingBack = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        start_pos = new Vector3(7, -0.6f, 0);
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Pos = transform.position;


    }
    void Back()
    {
        float distance = Vector3.Distance(start_pos, transform.position);
        Vector2 pos;

        pos = start_pos - transform.position;

        _rigidbody.velocity = pos.normalized * 5;

        Debug.Log("H");
        if (Mathf.Abs(distance) <= 1)
            back = false;
        Pos = transform.position;
    }

    void MoveRight()
    {
        Pos += transform.right * Time.deltaTime * (moveSpeed - 2);
        transform.position = Pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

    }
    void MoveLeft()
    {
        Pos -= transform.right * Time.deltaTime * (moveSpeed - 2);
        transform.position = Pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

    }
    void CheckWhereToForce()
    {
        if (Pos.x < -7f)
        {
            facingRight = true;
        }
        else if (Pos.x > 7f)
        {
            facingRight = false;
        }

    }

    void Chasing()
    {

        Vector2 pos;

        pos = targetPos - transform.position;

        _rigidbody.velocity = pos.normalized * 5;
        
        Pos = transform.position;

        //if (targetPos.x > transform.position.x)
        //{
        //    // transform.localScale = new Vector3(0.96995f, 1.50865f, 1);
        //    Vector3 MoveVelocity = Vector3.right;
        //    transform.position = Vector3.Lerp(transform.position, targetPos, (moveSpeed - 3) * Time.deltaTime);

        //}
        //else if (targetPos.x < transform.position.x)
        //{
        //    //  transform.localScale = new Vector3(-0.96995f, 1.50865f, 1);
        //    Vector3 MoveVelocity = Vector3.left;
        //    transform.position = Vector3.Lerp(transform.position, targetPos, (moveSpeed - 3) * Time.deltaTime);
        //}
        Debug.Log("chaseeee");

    }

    void Viator()
    {

        CheckWhereToForce();


        if (facingRight)
        {
            MoveRight();
            Debug.Log("C");

        }
        else if (!facingRight)
        {
            MoveLeft();
            Debug.Log("D");

        }

    }


    private void Update()
    {
        targetPos = target.transform.position;
        float Distance = Vector3.Distance(targetPos, transform.position);
        if (Mathf.Abs(Distance) <= 3 && Mathf.Abs(Distance) > 1 && !back)
            chasing = true;
        else if (Mathf.Abs(Distance) <= 1)
        {
            back = true;
            chasing = false;
        }
        else
            chasing = false;

        if (back)
            Back();

        else
        {
            if (chasing)
                Chasing();
            else
                Viator();

        }
    }
    /*
    void Update()
    {
        CheckWhereToForce();

        targetPos = target.transform.position;
        float Distance = Vector3.Distance(targetPos, transform.position);

        if (Mathf.Abs(Distance) <= 5 && chasing)
        {

            if (targetPos.x > transform.position.x)
            {
               // transform.localScale = new Vector3(0.96995f, 1.50865f, 1);
                Vector3 MoveVelocity = Vector3.right;
                transform.position = Vector3.Lerp(transform.position, targetPos, (moveSpeed - 3) * Time.deltaTime);

            }
            else if (targetPos.x < transform.position.x)
            {
              //  transform.localScale = new Vector3(-0.96995f, 1.50865f, 1);
                Vector3 MoveVelocity = Vector3.left;
                transform.position = Vector3.Lerp(transform.position, targetPos, (moveSpeed - 3) * Time.deltaTime);
            }

        }
        else if (Mathf.Abs(Distance) > 5)
        {
            if (facingRight)
            {
                MoveRight();
                Debug.Log("C");

            }
            else if (!facingRight)
            {
                MoveLeft();
                Debug.Log("D");

            }

        }

    }
    void CheckWhereToForce()
    {
        if (Pos.x < -7f)
        {
            facingRight = true;
        }
        else if (Pos.x > 7f)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    void MoveRight()
    {
        Pos += transform.right * Time.deltaTime * (moveSpeed-2);
        transform.position = Pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
        
    }
    void MoveLeft()
    {
        Pos -= transform.right * Time.deltaTime * (moveSpeed-2);
        transform.position = Pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

    }
    void GetBack()
    {
        MovingBack = true;
        
    }
    void Down()
    {
        MovingBack = false;
    }*/
}

