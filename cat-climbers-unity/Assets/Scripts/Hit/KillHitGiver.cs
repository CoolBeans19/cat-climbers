using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillHitGiver : HitGiver {
    public override void GiveHit(HitReciever h)
    {
        h.GetComponent<StateMachine>().InteruptTo(h.GetComponent<DeadState>());
    }
}
