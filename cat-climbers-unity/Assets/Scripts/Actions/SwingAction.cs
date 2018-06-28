using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAction : BaseAction, IAction {

    
    private Rope rope;
    private DistanceJoint2D joint;
    private RopeTarget myTarget;
    private RopeTarget partner;

    public SwingAction(State s) : base(s)
    {
        rope = GameObject.FindObjectOfType<Rope>();
        joint = ownerState.GetComponent<DistanceJoint2D>();
        myTarget = ownerState.GetComponent<RopeTarget>();
    }

    public void EnterAct()
    {
        partner = rope.GetPartner(myTarget);
        joint.distance = Vector2.Distance(myTarget.transform.position, partner.transform.position);
        joint.enabled = true;
        joint.connectedBody = partner.GetComponent<Rigidbody2D>();

    }

    public void LeaveAct()
    {
        joint.enabled = false;
    }

    public void UpdateAct()
    {

    }

}
