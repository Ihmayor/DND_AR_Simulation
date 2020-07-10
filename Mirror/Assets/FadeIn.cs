using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
 
    private float fadeOutSpeed = 0.03f;
    public float delay = 3.5f;
    private bool start;
    public void Start()
    {
        start = false;
    }
    void OnBecameVisible()
    {
        if (isActiveAndEnabled && !start)
        {
            Debug.Log("Became Visible: " + gameObject.name);
            StartCoroutine(Fading(1, delay));

        }
    }

    private void OnBecameInvisible()
    {
        if (isActiveAndEnabled && !start)
        {
            Debug.Log("Became Invisible: " + gameObject.name);
            
            StartCoroutine(FadingOut(0, 1));
        }
    }
    IEnumerator Fading(float desiredAlpha, float delay)
    {
        start = true;
        yield return new WaitForSeconds(delay);
        SpriteRenderer fadeOutImage = GetComponent<SpriteRenderer>();
        float startingAlpha = fadeOutImage.color.a;
       
        float maintainR = fadeOutImage.color.r;
        float maintainG = fadeOutImage.color.g;
        float maintainB = fadeOutImage.color.b;
        while (desiredAlpha > fadeOutImage.color.a)
        {
            fadeOutImage.color = new Color(maintainR, maintainG, maintainB, fadeOutImage.color.a+fadeOutSpeed);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        start = false;
    }

    IEnumerator FadingOut(float desiredAlpha, float delay)
    {
        start = true;
        yield return new WaitForSeconds(delay);
        SpriteRenderer fadeOutImage = GetComponent<SpriteRenderer>();
        float startingAlpha = fadeOutImage.color.a;

        float maintainR = fadeOutImage.color.r;
        float maintainG = fadeOutImage.color.g;
        float maintainB = fadeOutImage.color.b;
        while (desiredAlpha < fadeOutImage.color.a)
        {
            fadeOutImage.color= new Color(maintainR, maintainG, maintainB, fadeOutImage.color.a - fadeOutSpeed);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        start = false;
    }

}
