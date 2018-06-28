using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeThrowingState : State
{
    private RopePocketState pocket;
    private RopeConnectedState connect;
    private Rope rope;

    public float castTime ;
    public LineRenderer lr;

    public override void Start()
    {
        pocket = GetComponent<RopePocketState>();
        connect = GetComponent<RopeConnectedState>();
        lr = GetComponent<LineRenderer>();
        rope = GetComponent<Rope>();
        base.Start();

    }


    public void Miss()
    {
        print("missed!");
        rope.connectee = null;
        rope.SpawnTooFarMessage();
        return;
    }
    public void Hit(RopeTarget r)
    {
        print("hit!");
        rope.connectee = r;
        r.Attach(rope);        
        return;
    }

    public override void EnterAction()
    {
        lr.useWorldSpace = true;

        base.EnterAction();
        RopeTarget[] Rt = FindObjectsOfType<RopeTarget>();
        RopeTarget targ = ValidTarget(Rt);
        if (targ !=null)
        {
            Hit(targ);          
        }
        else
        {
            Miss();
        }
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        UpdateRopePos();

        TransitionOut();
    }

    private void UpdateRopePos()
    {

        if (rope.connectee != null)
        {
            lr.enabled = true;

            lr.SetPosition(0, rope.owner.transform.position);
            lr.SetPosition(1, Vector3.Lerp(rope.owner.transform.position
                , rope.connectee.transform.position
                ,stateMachine.timeSinceLastChange/castTime ));
        }
    }

    private void TransitionOut()
    {
        if (stateMachine.timeSinceLastChange > castTime)
        {
            if (rope.connectee == null)
            {
                stateMachine.TransitionTo(GetComponent<RopePocketState>());
            }
            else
            {
                stateMachine.TransitionTo(connect);
            }
        }
    }

    public override void LeaveAction()
    {
        base.LeaveAction();
        print("left throw state...");
    }

    private RopeTarget ValidTarget(RopeTarget[] rt)
    {
        foreach (RopeTarget r in rt)
        {
            if (r == null)
            {
                print("ur null bro...");
                continue;
            }
            if (r == GetComponent<Item>().owner.GetComponent<RopeTarget>())
            {
                print("ur hitting urself bro...");

                continue;
            }

            if (Vector2.Distance(GetComponent<Item>().owner.transform.position, r.transform.position) > rope.length)
            {
                print("ur too far bro...");

                continue;
            }
            print("u made it! returning u " + r.name);
            return r;
        }

        return null;
    }
}
