using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePocketState : State {

    public LineRenderer lr;


    new public void Awake()
    {
        base.Awake();
        lr = GetComponent<LineRenderer>();
    }

    public void Throw()
    {
        stateMachine.TransitionTo(GetComponent<RopeThrowingState>());
        return;
    }

    public override void EnterAction()
    {

        base.EnterAction();
        lr.enabled = true;
        lr.useWorldSpace = false;
        lr.SetPosition(0, new Vector3(0.3f, -0.2f));
        lr.SetPosition(1, new Vector3(0.3f, -2));
    }

    public override void LeaveAction()
    {
        base.LeaveAction();
        lr.enabled = false;
    }



}
