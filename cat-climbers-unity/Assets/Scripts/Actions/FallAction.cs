using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAction : BaseAction, IAction
{
    static float gravity = 15;
    private Rigidbody2D rigid;

    public FallAction(State s) : base(s)
    {
        rigid = s.GetComponent<Rigidbody2D>();
    }

    public void EnterAct()
    {
    }

    public void LeaveAct()
    {
    }

    public void UpdateAct()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y - Time.deltaTime * gravity);
    }
}
