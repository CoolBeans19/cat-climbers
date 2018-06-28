using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HitSpaceToPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("GrabWall1") || Input.GetButtonDown("GrabWall2"))
        {
            SceneManager.LoadScene(1);
        }

    }
}
