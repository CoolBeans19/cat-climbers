using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public GameObject owner;

    public virtual void Start()
    {
        owner = null;
    }

    public virtual void Use()
    {

    }


    public void Exchange(GameObject g)
    {
        Take();
        SetOwner(g);
        Give();
    }

    public virtual void SetOwner(GameObject g)
    {
        owner = g;
        transform.parent = owner.transform;
        transform.localPosition = Vector3.zero;
    }

    private void Give()
    {
        IItemState[] states = owner.GetComponents<IItemState>();
        foreach (IItemState s in states)
        {
            RegisterAction((State)s);
        }
    }

    private void Take()
    {
        if (owner != null)
        {
            IItemState[] prevStates = owner.GetComponents<IItemState>();
            foreach (IItemState s in prevStates)
            {
                UnregisterAction((State)s);//s.listeners.RemoveAll((x) => x.GetType().ToString() == typeof(RopeThrowListener).ToString());
            }
        }
    }

    public virtual void RegisterAction(State s) {
        s.AddListener(new ItemUseListener(s, s.GetComponent<IUseItem>().GetEvent(), this));
    }
    public virtual void UnregisterAction(State s) {
        s.RemoveListener(typeof(ItemUseListener).ToString());
    }

}
