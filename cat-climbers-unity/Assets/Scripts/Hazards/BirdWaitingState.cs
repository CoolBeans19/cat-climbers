using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdWaitingState : State {

    public float waitTime;
    private BirdFlyingState fly;
    private AudioSource aud;

    public override void Start()
    {
        base.Start();
        fly = GetComponent<BirdFlyingState>();
        aud = GetComponent<AudioSource>();
        DifficultyManager.inst.onDifficultyChange.AddListener(UpdateWaitTime);
    }


    public override void EnterAction()
    {
        base.EnterAction();
        transform.position = new Vector3(0, 10000, 0);
    }
    public override void UpdateAction()
    {
        
        base.UpdateAction();
        if(stateMachine.timeSinceLastChange > waitTime -4)
        {
            aud.Play();
        }

        if (stateMachine.timeSinceLastChange > waitTime)
        {

            stateMachine.TransitionTo(fly);
        }
    }

    public void UpdateWaitTime(int difficulty)
    {
        if(difficulty <4)
        {
            waitTime = 15;
        }
        if (difficulty == 4)
        {
            waitTime = 10;
        }
        if (difficulty == 5)
        {
            waitTime = 5;
        }
    }


}
