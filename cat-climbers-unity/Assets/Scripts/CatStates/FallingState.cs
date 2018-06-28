using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : State , IItemState{
    private PlayerInput inp;
    private Rope rope;

    public override void Start()
    {
        inp = GetComponent<PlayerInput>();
        rope = FindObjectOfType<Rope>();
        base.Start();
        actions.Add(new FallAction(this));
        listeners.Add(new WallGrabListener(this, inp.wallGrab));
        listeners.Add(new TransitionListener(this, GetComponent<SwingState>(), rope.GetComponent<RopeConnectedState>().onConnect));
    }

    public override void EnterAction()
    {
        base.EnterAction();
        anim.Play("fall");
    }

}
