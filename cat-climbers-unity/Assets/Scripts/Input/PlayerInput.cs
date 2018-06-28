using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerInput : CatInput{
    public int playerNum;

    private void Update()
    {
        if (Input.GetButtonDown("UseItem"+playerNum))
        {
            itemDown.Invoke();
        }
        if (Input.GetButtonUp("UseItem" + playerNum))
        {
            itemUp.Invoke();
        }
        if (Input.GetButtonDown("GrabWall" + playerNum)){
            wallGrab.Invoke();
        }
        if (Input.GetButtonUp("GrabWall" + playerNum))
        {
            wallRelease.Invoke();
        }
        InvokeMove(new Vector2(Input.GetAxisRaw("Horizontal" + playerNum), Input.GetAxisRaw("Vertical" + playerNum)));

    }

}
