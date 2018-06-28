using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    Rigidbody2D rigid;
    public override void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        base.Start();
        actions.Add(new FallAction(this));
    }
    public override void EnterAction()
    {
        base.EnterAction();
        anim.Play("ko");
       rigid.velocity = new Vector2(Random.Range(-4, 4), 5);
        rigid.constraints = RigidbodyConstraints2D.None;

        GetComponent<Rigidbody2D>().AddTorque(200);

    }
}
