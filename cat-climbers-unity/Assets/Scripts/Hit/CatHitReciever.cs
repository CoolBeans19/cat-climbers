using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHitReciever : HitReciever{

    public override void OnGetHit(HitGiver r)
    {
        GetComponent<RopeTarget>().Detach();
    }
}
