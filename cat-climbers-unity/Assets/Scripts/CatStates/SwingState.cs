using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingState : State
{
    private PlayerInput inp;
    private Rope rope;

    private RopeTarget partner;
    
    public override void Start()
    {
        rope = FindObjectOfType<Rope>();
        inp = GetComponent<PlayerInput>();
        base.Start();
        listeners.Add(new WallGrabListener(this, inp.wallGrab));
        actions.Add(new SwingAction(this));
        actions.Add(new FallAction(this));
        listeners.Add(new TransitionListener(this, GetComponent<FallingState>(), rope.onDisconnect));
        listeners.Add(new SwingDIListener(this, inp.moveUpdate, rope));
        //listeners.Add(new CallMethodListener(this, rope.onDisconnect, RefreshPartner));
    }

    public override void EnterAction()
    {
        base.EnterAction();
        anim.Play("fall");
        partner = rope.GetPartner(GetComponent<RopeTarget>());

        EncumberPartner();

    }

    public override void LeaveAction()
    {
        base.LeaveAction();
        RefreshPartner();

    }

    private void EncumberPartner()
    {
        Stats s =partner.GetComponent<Stats>(); //fetch the other rope player's stats
        if (s != null)
        {
            s.EncumberSpeed();
        }
    }
    public void RefreshPartner()
    {
        print("calling refresh partner");
       Stats s = partner.GetComponent<Stats>(); //fetch the other rope player's stats
        if (s != null)
        {
            s.RefreshSpeed();
        }
    }

    }

    



