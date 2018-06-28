using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGiver : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitReciever h = collision.GetComponent<HitReciever>();
        if (h != null)
        {
            GiveHit(h);
            //h.onRecieveHit.Invoke(this);
            h.OnGetHit(this);
        }
    }

    public virtual void GiveHit(HitReciever h)
    {

    }

}
