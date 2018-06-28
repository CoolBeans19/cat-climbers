using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RopeTarget : MonoBehaviour
{

    public bool consenting;
    public UnityEvent revokeConsent;

    public Rope rope;
    public bool connected;


    public State GetState()
    {
        
        if (rope!=null && rope.GetConnected())
        {
            return GetComponent<SwingState>();
        }
        else
        {
            return GetComponent<FallingState>();
        }
    }


    public void Detach()
    {
        if(rope!= null)
        {
            connected = false;
            rope.Disconnect(this);
        }
    }

    public void Attach(Rope r)
    {
        rope = r;
        connected = true;
    }


    private void Start()
    {
        connected = false;
        CatInput c = GetComponent<CatInput>();

        if (c != null)
        {
            c.itemUp.AddListener(Detach);
        }
    }



    /*
    public void RevokeConsent()
    {
        consenting = false;
        revokeConsent.Invoke();
    }

    public bool GetConsent()
    {
        return consenting;
    }
    */
}
