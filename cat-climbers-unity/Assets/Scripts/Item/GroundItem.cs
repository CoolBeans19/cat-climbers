using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IItemState>() != null)
        {
            GetComponent<Item>().Exchange(collision.gameObject);
            Destroy(this);
        }
    }
}
