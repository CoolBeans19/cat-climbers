using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RopeConnectedState : State {

    

    public Rope rope;

	public LineRenderer lr;

    public UnityEvent onConnect;
    private RopePocketState pocket;

    new public void Awake()
    {
        base.Awake();
       
    }
    public override void Start()
    {
        base.Start();
        pocket = GetComponent<RopePocketState>();
        rope = GetComponent<Rope>();
		lr = GetComponent<LineRenderer>();

		lr.enabled = false;
    }

    public override void EnterAction()
    {
        base.EnterAction();
        //SetupRevokers();

        onConnect.Invoke();
        lr.enabled = true;
        lr.useWorldSpace = true;
        //EncumberSpeeds();
    }


    public override void UpdateAction()
    {
        UpdateRope();

        base.UpdateAction();
    }

    public override void LeaveAction()
    {
        base.LeaveAction();
        //StopRevokers();

		lr.enabled = false;

      //  RefreshSpeeds();

    }
    public void UpdateRope()
    {
        lr.SetPosition(0, rope.ownerTarget.transform.position);
        lr.SetPosition(1, rope.connectee.transform.position);

        if (Vector2.Distance(rope.ownerTarget.transform.position, rope.connectee.transform.position) > rope.length)
        {
            rope.SpawnTooFarMessage();
            rope.Disconnect(rope.connectee);
        }
    }
    //depreceated methods
    /*
     
     
    private void EncumberSpeeds()
    {
        Stats statsOwner = rope.ownerTarget.GetComponent<Stats>();
        Stats statsHolder = rope.connectee.GetComponent<Stats>();

        if (statsOwner != null)
        {
            statsOwner.EncumberSpeed();
        }
        if (statsHolder != null)
        {
            statsHolder.EncumberSpeed();
        }
    }
    private void RefreshSpeeds()
    {
        Stats statsOwner = rope.ownerTarget.GetComponent<Stats>();
        Stats statsHolder = rope.connectee.GetComponent<Stats>();

        if (statsOwner != null)
        {
            statsOwner.RefreshSpeed();
        }
        if (statsHolder != null)
        {
            statsHolder.RefreshSpeed();
        }
    } 
      
    private void SetupRevokers()
    {
        connectee.revokeConsent.AddListener(ConnecteeDisconnect);

        ownerTarget = item.owner.GetComponent<RopeTarget>();
        if (ownerTarget != null)
        {
            ownerTarget.revokeConsent.AddListener(OwnerDisconnect);
        }
        else
        {
            Debug.Log("no target found on owner");
        }
    }
    private void StopRevokers()
    {
        connectee.revokeConsent.RemoveAllListeners();
        if (ownerTarget != null)
        {
            ownerTarget.revokeConsent.RemoveAllListeners();
        }
    }
   
    public void OwnerDisconnect()
    {
        if(connectee.GetComponent<IUseItem>() != null)
        {
           item.Exchange(connectee.gameObject);
        }
        stateMachine.TransitionTo(pocket);

        return;
    }
    public void ConnecteeDisconnect()
    {
        stateMachine.TransitionTo(pocket);
        return;
    }
    
     public RopeTarget GetPartner(RopeTarget r)
    {
        if (ownerTarget == r)
            return connectee;
        if (connectee == r)
            return ownerTarget;
        return null;

    }
    */



}
