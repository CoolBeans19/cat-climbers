using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void IActionDelegate(IAction a);
public delegate void IListenerDelegate(IListener l);


[System.Serializable]
public class State : Transitionable
{
    
    public StateMachine stateMachine;
    public  Animator anim;


    public List<IAction> actions;


    public List<IListener> listeners;

    public virtual void Awake()
    {
        actions = new List<IAction>();
        listeners = new List<IListener>();
        anim = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
        badname = GetType().ToString();
    }

    public virtual void Start()
    {
        //anim = GetComponent<Animator>();
        //stateMachine = GetComponent<StateMachine>();
       // badname = GetType().ToString();
    }

    public void AddListener(IListener l)
    {
        listeners.Add(l);
        if(stateMachine.currentState == this)
        {
            l.Register();
        }
    }

    public void RemoveListener(IListener l)
    {
        l.Unregister();
        listeners.RemoveAll((x) => x.GetType().ToString() == l.GetType().ToString());
    }
    public void RemoveListener(string s)
    {
        List<IListener > l = listeners.FindAll((x) => x.GetType().ToString() == s);
        RunAllListeners(l, (x) => x.Unregister());
        listeners.RemoveAll((x) => x.GetType().ToString() == s);
    }


    private void RunAllActions(List<IAction> actions, IActionDelegate i )
    {
        foreach (var item in actions)
        {
            i.Invoke(item);
        }
    }
    

    private void RunAllListeners(List<IListener> events , IListenerDelegate i)
    {
        foreach (var item in events)
        {
            i.Invoke(item);
        }
    }


    public virtual void EnterAction() {
        RunAllActions( actions, (x)=>x.EnterAct() );
        RunAllListeners(listeners, (x)=>x.Register());
    }
    public virtual void UpdateAction() {
        RunAllActions(actions, (x) => x.UpdateAct());
       // RunAllListeners(listeners, (x) => Debug.Log(x.GetType().ToString()));
    }
    public virtual void LeaveAction() {
        RunAllActions(actions, (x) => x.LeaveAct());
        RunAllListeners(listeners, (x) => x.Unregister());
    }

    public bool Is(string s)
    {
        return (badname == s);
    }
    public bool Is(Type t)
    {
        return (badname == t.ToString());

    }

    #region junk
    public static bool operator ==(State obj1, String str)
    {
        if (object.ReferenceEquals(obj1, null))
        {
            return object.ReferenceEquals(str, null);
        }

        return (obj1.badname == str);
    }

    public static bool operator !=(State obj1, String str)
    {
        if (object.ReferenceEquals(obj1, null))
        {
            return !object.ReferenceEquals(str, null);
        }
        return (obj1.badname != str);
    }

    public override bool Equals(System.Object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return badname == ((State)obj).badname;
    }

    public override int GetHashCode()
    {
        return badname.GetHashCode();
    }
    #endregion junk
}
