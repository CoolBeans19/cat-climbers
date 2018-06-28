using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	// Speed at which the score increases
	public float scoreRate = 1.0f;
	public float currentScore;

	public int highScore;

	public Text scoreText;

    public Transform progress;

	// Use this for initialization
	void Start () {
        progress = Camera.main.transform;
		currentScore = 0;

		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();

		scoreText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        //currentScore += Time.deltaTime * scoreRate;
        currentScore = progress.position.y;
		if (currentScore > highScore) {
			highScore = (int)currentScore * 100;
		}

		UpdateText ();
	}

	void UpdateText () {
		scoreText.text = (((int)currentScore * 100)).ToString();
	}
}
