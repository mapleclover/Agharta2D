using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Singleton<PlayerMove>
{
    public int speed = 5;
    public float xMove;
    public float yMove;
    public Vector3 pos;
    public bool facingRight = true;

    void Flip()
    {
       // transform.position += moveVelocity * speed * Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 moveVelocity = Vector3.zero;
        pos = this.transform.position;

        if (!PauseMenu.Instance.freeze)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(-1, 1, 1);
            }

            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양 
        yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축으로 이동할양 
        if (xMove < 0)
            facingRight = false;
        else if (xMove > 0)
            facingRight = true;
        this.transform.Translate(new Vector3(xMove, yMove, 0));  //이동

    }
}
