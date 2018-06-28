using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEvent : UnityEvent<int> { }


public class DifficultyManager : MonoBehaviour {
    //the ideas for the difficulty is that
    //0 is the difficulty where you are getting used to climbing, no hazards
    //1 is the difficulty where rocks fall occasionally 
    //2 is the difficulty where rocks fall more
    //3 spawns birds, more rocks

    public IntEvent onDifficultyChange;
    public static DifficultyManager inst;

    public Transform progress;

    public float[] heightToIncreaseDifficulty;
    public int difficulty;

    private void Awake()
    {
        if(onDifficultyChange == null)
        {
            onDifficultyChange = new IntEvent();
        }

        inst = this;
    }

    private void Start()
    {
        difficulty = 0;
        onDifficultyChange.Invoke(difficulty);
        progress = Camera.main.transform;
    }


    private void Update()
    {
        if (difficulty < heightToIncreaseDifficulty.Length - 1)
        {
            if (progress.position.y > heightToIncreaseDifficulty[difficulty])
            {
                IncrementDifficulty();
            }
        }
    }

    private void IncrementDifficulty()
    {
        difficulty++;
        onDifficultyChange.Invoke(difficulty);
    }
}
