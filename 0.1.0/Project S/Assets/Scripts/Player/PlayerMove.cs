using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public Vector2 inputVec;

    Rigidbody2D rigid;

    public bool isTouchTop;
    public bool isTouchLeft;
    public bool isTouchRight;
    public bool isTouchBottom;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        if((isTouchRight && inputVec.x == 1) || (isTouchLeft && inputVec.x == -1)){
            inputVec.x = 0;
        }

        inputVec.y = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && inputVec.y == 1) || (isTouchBottom && inputVec.y == -1)){
            inputVec.y = 0;
        }
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top" :
                    isTouchTop = true;
                    break;

                case "Left":
                    isTouchLeft = true;
                    break;

                case "Right":
                    isTouchRight = true;
                    break;

                case "Bottom":
                    isTouchBottom = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;

                case "Left":
                    isTouchLeft = false;
                    break;

                case "Right":
                    isTouchRight = false;
                    break;

                case "Bottom":
                    isTouchBottom = false;
                    break;
            }
        }
    }
}
