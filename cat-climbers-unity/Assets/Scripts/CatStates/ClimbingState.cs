using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : State , IItemState
{
    private RopeConnectedState connected;
    private PlayerInput inp;

    public override void Start()
    {
        connected = FindObjectOfType<RopeConnectedState>();
        inp = GetComponent<PlayerInput>();
        base.Start();
        listeners.Add(new ClimbingListener(this, inp.move));
        listeners.Add(new WallReleaseListener(this, inp.wallRelease));
        actions.Add(new CheckWallAction(this));
        actions.Add(new ParticleAction(this, ParticleManager.inst.dustParticle));
    }

    public override void EnterAction()
    {
        base.EnterAction();
        anim.Play("climb");
    }
}
