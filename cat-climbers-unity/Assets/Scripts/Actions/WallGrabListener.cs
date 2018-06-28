using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WallGrabListener : IListener
{
    public UnityEvent trigger;
    public Transform transfrom;
    public State ownerState;

    public WallGrabListener(State state, UnityEvent trig)
    {
        ownerState = state;
        transfrom = state.transform;
        trigger = trig;
    }

    public void Register()
    {
        trigger.AddListener(WallGrab);
        Debug.Log("wsafasfa");
    }

    public void Unregister()
    {
        trigger.RemoveListener(WallGrab);
    }

    public void WallGrab()
    {
        if (CheckWall.med(transfrom.position))
        {
            ownerState.stateMachine.TransitionTo(ownerState.GetComponent<ClimbingState>());
            return;
        }
    }


    

}
