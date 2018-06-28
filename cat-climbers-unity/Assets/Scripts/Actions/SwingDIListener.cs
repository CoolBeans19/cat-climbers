using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingDIListener : MoveListener
{
    private Rope rope;
    private Transform targ;
    public SwingDIListener(State s, VectorEvent v, Rope r) : base(s, v)
    {
        rope = r;
    }
    public override void Register()
    {
        targ = rope.GetPartner(ownerState.GetComponent<RopeTarget>()).transform;
        base.Register();
    }
    public override void Move(Vector2 v)
    {
        if (v == Vector2.zero)
        {

            return;
        }

        if (rigid.velocity.magnitude > 20)
        {

            return;
        }

        Vector3 tangent = Vector3.Cross(targ.position - ownerState.transform.position, Vector3.back).normalized;
        Vector2 mov = tangent * Vector2.Dot(tangent, v);
        rigid.AddForce(mov , ForceMode2D.Impulse);
    }
}
