using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WallReleaseListener : IListener
{
    public UnityEvent trigger;
    public State ownerState;
    private Rope rope;


    public WallReleaseListener(State state, UnityEvent trig)
    {
        ownerState = state;
        trigger = trig;
        rope = GameObject.FindObjectOfType<Rope>();
    }

    public void Register()
    {
        trigger.AddListener(WallRelease);
    }

    public void Unregister()
    {
        trigger.RemoveListener(WallRelease);
    }

    public void WallRelease()
    {
        ownerState.stateMachine.TransitionTo(ownerState.GetComponent<RopeTarget>().GetState());
        return;
    }

}
