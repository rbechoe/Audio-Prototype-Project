using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareObject : MonoBehaviour
{
    public int ball;
    Material mymat;
    float time;

    float ballRemover = 0.5f;

    void Start()
    {
        mymat = gameObject.GetComponent<Renderer>().material;
    }

    public void FireSnare()
    {
        if (ball > 0)
        {
            mymat.color = Color.green;
        }
        else
        {
            mymat.color = Color.red;
        }

        time = 0.5f;
    }

    void Update()
    {
        if (time <= 0 && mymat.color != Color.white)
        {
            mymat.color = Color.white;
        }

        if (time > 0) time -= Time.deltaTime;

        if (ball > 0)
        {
            ballRemover -= Time.deltaTime;
            if (ballRemover < 0)
            {
                ball--;
                ballRemover = 0.5f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ball++;
    }

    void OnTriggerExit(Collider other)
    {
        ball--;
    }
}
