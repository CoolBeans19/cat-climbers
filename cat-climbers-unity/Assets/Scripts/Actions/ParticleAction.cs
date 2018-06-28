using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAction : BaseAction, IAction
{
    private GameObject particle;

    public ParticleAction(State s, GameObject _particle) : base(s)
    {
        particle = _particle;
    }

    public void EnterAct()
    {
        ParticleManager.inst.Spawn(particle, ownerState.transform.position);
    }

    public void LeaveAct()
    {
    }

    public void UpdateAct()
    {
    }
}
