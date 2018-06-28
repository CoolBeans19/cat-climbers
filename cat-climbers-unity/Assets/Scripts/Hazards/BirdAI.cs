using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour {
    private Rigidbody2D rigid;
    private int bound = 20;
    private float speed = 12;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        CheckForTurn();
        //if()

    }

    private void CheckForTurn()
    {
        if (transform.position.x < -bound && rigid.velocity.x < 0)
        {
           // SetHeight();
            rigid.velocity = speed * Vector2.right;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (transform.position.x > bound && rigid.velocity.x > 0)
        {
            //transform.position = SetHeight();
            rigid.velocity = speed * Vector2.left;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    

   
}
