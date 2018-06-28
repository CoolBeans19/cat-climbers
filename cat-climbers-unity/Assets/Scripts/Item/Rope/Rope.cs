using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rope : Item
{
    public UnityEvent onDisconnect;


    public StateMachine stateMachine;
    private RopeConnectedState connected;
    private RopePocketState pocket;

    public RopeTarget connectee;
    public RopeTarget ownerTarget;
    public GameObject tooFar;


    public float length;

    public void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        connected = GetComponent<RopeConnectedState>();
        pocket = GetComponent<RopePocketState>();

        if (onDisconnect == null)
        {
            onDisconnect = new UnityEvent();
        }
    }

   


    public RopeTarget GetPartner(RopeTarget r)
    {
        if (stateMachine.currentState.Is(typeof(RopeConnectedState)))
        {
            if (ownerTarget == r)
                return connectee;
            if (connectee == r)
                return ownerTarget;
            return null;
        }
        return null;
    }

    public bool GetConnected()
    {
        if(stateMachine.currentState.Is(typeof(RopeConnectedState)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public State GetReleaseState(State s)
    {
        if (stateMachine.currentState.Is(typeof(RopeConnectedState)))
        {
            return s.GetComponent<SwingState>();
        }
        else
        {
            return s.GetComponent<FallingState>();
        }
    }

    public void Disconnect(RopeTarget r )  // disconnect the rope, the disconnect is initiated by the target being passed in
    {
        if (stateMachine.currentState.Is(typeof(RopeConnectedState))) {
            onDisconnect.Invoke();


            if (r == ownerTarget)
            {
                if (connectee.GetComponent<IUseItem>() != null)
                {
                    Exchange(connectee.gameObject);
                }
            }


            stateMachine.TransitionTo(pocket);


        }
    }

    public void SpawnTooFarMessage()
    {
        Instantiate(tooFar, transform.position, Quaternion.identity);
    }

    public override void Use()
    {
        base.Use(); 
        if(stateMachine.currentState is RopePocketState)
        {
            ((RopePocketState)stateMachine.currentState ).Throw();
        }

    }

    public override void SetOwner(GameObject g)
    {
        print("setting ownr");
        base.SetOwner(g);
        ownerTarget = owner.GetComponent<RopeTarget>();
        print(ownerTarget.name);
        ownerTarget.Attach(this);
    }

}
