using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitGiverEvent : UnityEvent<HitGiver> { }

public class HitReciever : MonoBehaviour {
    [HideInInspector]
    public StateMachine stateMachine;
    [HideInInspector]
    public Rigidbody2D rigid;

    public HitGiverEvent onRecieveHit;

    private void Awake()
    {
        if(onRecieveHit == null)
        {
            onRecieveHit = new HitGiverEvent();
        }
    }

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        rigid = GetComponent<Rigidbody2D>();
    }
    public virtual void OnGetHit(HitGiver r)
    {

    }

}
