using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DetectDeath : MonoBehaviour {

    public Fade wasted;
    public Fade fade;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<ClimbingState>())
        {

            StartCoroutine("GameOver");


        }


    }


    IEnumerator GameOver()
    {
        Time.timeScale = 0.3f;

        wasted.In(1);
        fade.In(0.3f);

        yield return new WaitForSecondsRealtime(2.5f);
        Time.timeScale = 1;

        SceneManager.LoadScene(0);


    }



}
