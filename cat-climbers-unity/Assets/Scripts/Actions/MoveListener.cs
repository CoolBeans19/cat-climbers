using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveListener : BaseAction, IListener
{
   // protected float speed;
    protected Rigidbody2D rigid;
    public VectorEvent moveEvent;
    public Stats stats;


    public MoveListener(State s, VectorEvent v) : base(s)
    {
        rigid = ownerState.GetComponent<Rigidbody2D>();
        moveEvent = v;
        stats = ownerState.GetComponent<Stats>();
    }

    public virtual void Register()
    {
        //speed = ownerState.GetComponent<Stats>().currentMoveSpeed;
        moveEvent.AddListener(Move);
    }

    public void Unregister()
    {
        moveEvent.RemoveListener(Move);
    }

    public virtual void Move(Vector2 v)
    {
        rigid.velocity = stats.currentMoveSpeed * v.normalized;
    }
}
