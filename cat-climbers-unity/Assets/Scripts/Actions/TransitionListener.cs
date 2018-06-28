using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TransitionListener : BaseAction, IListener
{
    public UnityEvent trigger;
    private State target;

    public virtual void Transition()
    {
        ownerState.stateMachine.TransitionTo(target);
    }

    public TransitionListener(State s, State targetState, UnityEvent trig) : base(s)
    { 
        target = targetState;
        trigger = trig;
    }

    public void Register()
    {
        trigger.AddListener(Transition);

    }

    public void Unregister()
    {
        trigger.RemoveListener(Transition);
    }
}
