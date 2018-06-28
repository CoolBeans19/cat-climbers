using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoHitGiver : HitGiver {
    public override void GiveHit(HitReciever h)
    {
        KnockedOutState ko =  h.GetComponent<KnockedOutState>();
        h.stateMachine.InteruptTo(ko);
    }
}
