using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Transitionable : MonoBehaviour {
    public string badname;
    public List<string> transitions;

    public Transitionable()
    {
      //  transitions = new List<Transitionable>();
    }
    public Transitionable(string nam) : base()
    {
        badname = nam;
    }


    protected bool CheckValidTransition(string s)
    {
       string t = transitions.Find(x => x == s);
        if(t != null && t != "")
        {
            return true;
        }
        return false;
    }

    public bool CanTransitionToState(string nextTransitionable)
    {
        return CheckValidTransition(nextTransitionable);
    }
}
