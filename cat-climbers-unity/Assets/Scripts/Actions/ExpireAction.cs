using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate State StateGetter();

public class ExpireAction : IAction
{
    private StateMachine stateMachine;
    private StateGetter targetState;

    private float stunTime;

    public ExpireAction(StateMachine machine, StateGetter toState, float time)
    {
        stateMachine = machine;
        targetState = toState;
        stunTime = time;
    }


    public void EnterAct()
    {    
    }

    public void LeaveAct()
    {
    }

    public void UpdateAct()
    {

        if (stateMachine.timeSinceLastChange >stunTime)
        {
            stateMachine.TransitionTo(targetState());
            return;
        }
    }
}
