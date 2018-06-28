using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    
    public float currentMoveSpeed;
    public float baseMoveSpeed;
    public float encumberedMoveSpeed;
    private void Start()
    {
        RefreshSpeed();

    }

    public void RefreshSpeed()
    {
        currentMoveSpeed = baseMoveSpeed;
    }

    public void EncumberSpeed()
    {
        currentMoveSpeed = encumberedMoveSpeed;
    }

}
