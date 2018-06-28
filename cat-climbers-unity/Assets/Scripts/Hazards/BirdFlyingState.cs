using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyingState : State {
    private Rigidbody2D rigid;
    public float offscreen;
    public int direction;
    public float speed;

    public override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
        offscreen = Camera.main.orthographicSize * 3f;

        direction = 1;
    }


    public override void EnterAction()
    {
        base.EnterAction();
        
        direction = direction * -1;
        rigid.velocity = speed * new Vector2(direction, 0) ;
        transform.position = new Vector3(offscreen * direction * -1,GetHeight(),0);
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        if (direction * transform.position.x >  offscreen)
        {
            stateMachine.TransitionTo(GetComponent<BirdWaitingState>());

            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    private float GetHeight()
    {
        return Camera.main.transform.position.y - 0.9f * Camera.main.orthographicSize;
    }


}
