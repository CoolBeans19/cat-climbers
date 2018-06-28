using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdOfflineState : State {
    public override void Start()
    {
        base.Start();
        DifficultyManager.inst.onDifficultyChange.AddListener(EngageBird);
    }



    public int birdDifficultyEngage;
    public void EngageBird(int n)
    {
        if (n >= birdDifficultyEngage)
        {
            stateMachine.TransitionTo(GetComponent<BirdWaitingState>());
        }
    }
}
