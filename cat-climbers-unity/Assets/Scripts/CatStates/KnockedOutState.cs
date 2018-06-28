using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockedOutState : State
{
    private FallingState fallState;

    public override void Start()
    {
        fallState = GetComponent<FallingState>();
        base.Start();
        actions.Add(new FallAction(this));
        actions.Add(new ExpireAction(stateMachine, GetComponent<RopeTarget>().GetState, 0.7f));
    }
    public override void EnterAction()
    {
        base.EnterAction();
        anim.Play("ko");
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-4, 4), 5);
    }
}
