
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallAction : BaseAction , IAction
{
    private Rigidbody2D rigid;
    RopeTarget targ;
    public CheckWallAction(State s) : base(s)
    {
        rigid = ownerState.GetComponent<Rigidbody2D>();
        targ = ownerState.GetComponent<RopeTarget>();
    }

    public void EnterAct()
    {
    }

    public void LeaveAct()
    {
    }

    public void UpdateAct()
    {
        if (!CheckWall.med(ownerState.transform.position))
        {
            ownerState.stateMachine.TransitionTo(targ.GetState());
            rigid.velocity.Scale(new Vector2( 0.2f, 1));
            return;
        }
    }
}
