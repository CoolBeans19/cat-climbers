using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

    public static ParticleManager inst;
    public GameObject dustParticle;
    public GameObject gravelParticle;



    private void Awake()
    {
        inst = this;
    }

    public void Spawn(GameObject particle, Vector3 pos)
    {
        Instantiate(particle, (Vector2)pos, Quaternion.identity);

    }

}
