using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMessage : MonoBehaviour {

    public float life;

    private void Start()
    {
        Invoke("Die", life);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2,2),10);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
