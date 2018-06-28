using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade : MonoBehaviour {

    public Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void In(float a)
    {
        StartCoroutine("FadeIn",a);
    }


    IEnumerator FadeIn(float val)
    {
        for (float f = 0f; f <= val; f += 0.1f)
        {
            
            Color c = img.color;
            c.a = f;
            img.color = c;
            yield return null;
        }
    }
}
