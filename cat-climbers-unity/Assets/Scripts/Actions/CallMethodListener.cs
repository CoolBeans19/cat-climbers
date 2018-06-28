using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void Action();

public class CallMethodListener : BaseAction, IListener
{
    public UnityEvent e;
    public Action action;

    public CallMethodListener(State s, UnityEvent ev, Action a ) : base(s)
    {
        e = ev;
        action = a;
    }

    public void Register()
    {
        e.AddListener( Call);
    }

    private void Call()
    {
        action.Invoke();
    }

    public void Unregister()
    {
        e.RemoveListener(Call);
    }
}
