using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingListener : MoveListener
{
    public ClimbingListener(State s, VectorEvent v) : base(s, v)
    {
        rigid = ownerState.GetComponent<Rigidbody2D>();
        moveEvent = v;
    }

    public override void Move(Vector2 v)
    {
        base.Move(v);
        if (v == Vector2.zero)
        {
            ownerState.anim.Play("idle");
        }
        else
        {
            ownerState.anim.Play("climb");
        }
    }



}
