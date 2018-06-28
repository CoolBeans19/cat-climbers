using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ItemUseListener : BaseAction, IListener {
    private Item item;

    public UnityEvent useItem;

    public ItemUseListener(State s, UnityEvent t, Item i) : base(s)
    {
        useItem = t;
        item = i;
    }

    public void Register()
    {
        useItem.AddListener(Throw);
    }

    private void Throw()
    {
        item.Use();
    }

    public void Unregister()
    {
        useItem.RemoveListener(Throw);
    }

}
