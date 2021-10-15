using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public Animator blinkingAnimation;

    public float transitionTime;

    [HideInInspector] public bool isBlinking;
    public int timeToBlink;
    [HideInInspector] public float timer;
    

    void Start()
    {
        timeToBlink = 5;
        MinusTime();
        isBlinking = false;

        //StartCoroutine(Blink());
    }

    void MinusTime()
    {
        if (isBlinking)
        {
            timeToBlink -= 1;
        }
    }

    void Update()
    {

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            if (isBlinking == true)
            {
                isBlinking = false;
            }
        }

        if (timer <= 0)
        {
            timer = 11;
            MinusTime();
            isBlinking = true;
            blinkingAnimation.GetComponent<Animation>().Play("BlinkingAnimation");
        }

        if (Input.GetButtonDown("Jump"))
        {
            isBlinking = true;
            blinkingAnimation.GetComponent<Animation>().Play("BlinkingAnimation");

            //if (isBlinking == true)
            //{
            //    isBlinking = false;
            //}

            timer = 11;
        }
        if(Input.GetKeyUp("b"))
        {
            isBlinking = false;
        }

    }

    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(transitionTime);
            blinkingAnimation.GetComponent<Animation>().Play("BlinkingAnimation");
        }
    }
}
