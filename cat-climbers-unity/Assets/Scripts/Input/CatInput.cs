using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VectorEvent : UnityEvent<Vector2> { }

public class CatInput : MonoBehaviour, IUseItem {

    public UnityEvent itemDown;
    public UnityEvent itemUp;
    public UnityEvent wallGrab;
    public UnityEvent wallRelease;
    public VectorEvent move;
    public VectorEvent moveUpdate;

    private Vector2 lastMove;

    public void InvokeMove(Vector2 v)
    {
        move.Invoke(v);
        if (CheckMove(v))
        {
            moveUpdate.Invoke(v);
            print("move update");
        }
        lastMove = v;

    }

    private bool CheckMove(Vector2 thisMove)
    {
        Vector2 c = thisMove - lastMove;
        if (Mathf.Abs(c.x) > 0.1)
            return true;
        if (Mathf.Abs(c.y) > 0.1)
            return true;
        return false;

    }

    private void Awake()
    {
        if (itemDown == null)
            itemDown = new UnityEvent();
        if (itemUp == null)
            itemUp = new UnityEvent();
        if (wallGrab == null)
            wallGrab = new UnityEvent();
        if (wallRelease == null)
            wallRelease = new UnityEvent();
        if (move == null)
            move = new VectorEvent();
        if (moveUpdate == null)
            moveUpdate = new VectorEvent();
    }
    public UnityEvent GetEvent()
    {
        return itemDown;
    }
}
