using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateEvent : UnityEvent<State> { }

[System.Serializable]
public class StateMachine : Transitionable
{
    #region variables

    public StateEvent onStateChange;

    [UnityEngine.SerializeField]
    public State currentState;



    public float lastStateChange = 0;
    public float timeSinceLastChange;

    #endregion variables


    #region init

    public virtual void Awake()
    {
        if (onStateChange == null)
            onStateChange = new StateEvent();

        lastStateChange = Time.time;
        
    }

    public void Start()
    {
        ((State)currentState).EnterAction();
    }

    #endregion init


    #region transition

    public bool InteruptTo(State s)
    {
       // print("tryna interupt " + s.badname);
      return Transition(s);
    }
    public bool TransitionTo(State s)
    {
        //print("attempting a legal transition to " + s.badname);
        if(currentState == null) { return true; }
       if (!currentState.CanTransitionToState(s.badname))
       {
           //return false;// this is what controls allowed transitions. 
       }
       return Transition(s);
    }


    private bool Transition(State nextTransitionable)
    {
       if (nextTransitionable == null)
           return false;
        if (currentState == nextTransitionable)
           return false;
        //print("transitioning to " + nextTransitionable);

        lastStateChange = Time.time;
        onStateChange.Invoke((State)nextTransitionable);
       if (currentState is State && currentState != null)
       {
           ((State)currentState).LeaveAction();
       }

        currentState = nextTransitionable;

        if (currentState is State)
       {
            ((State)nextTransitionable).EnterAction();
        }
       return true;
    }





    #endregion transition


    #region updates

    public virtual void Update()
{
        //timeSinceLastChange.SetVal(Time.time - lastStateChange);
        timeSinceLastChange = Time.time - lastStateChange; 
   State s = (State)currentState;
   if (s != null) 
       s.UpdateAction();
}


#endregion updates





}



