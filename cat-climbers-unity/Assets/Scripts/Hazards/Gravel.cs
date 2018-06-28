using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravel : MonoBehaviour {
    public GameObject rock;

    private void Start()
    {
        ParticleManager.inst.Spawn(ParticleManager.inst.gravelParticle, transform.position );
        Invoke("Spawn", 1);
        Invoke("Destroy", 8);
    }

    private void Spawn()
    {
        rock = (GameObject)Instantiate(rock, transform.position, Quaternion.identity);
    }

    private void Destroy()
    {
        Destroy(rock);
        Destroy(gameObject);
    }

}
