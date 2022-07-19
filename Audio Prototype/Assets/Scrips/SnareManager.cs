using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnareManager : MonoBehaviour
{
    public AudioSource aSnare, sSnare, kSnare, lSnare; // A S K L
    public AudioClip snare;

    SnareObject aObj, sObj, kObj, lObj;

    void Start()
    {
        aObj = aSnare.gameObject.GetComponent<SnareObject>();
        sObj = sSnare.gameObject.GetComponent<SnareObject>();
        kObj = kSnare.gameObject.GetComponent<SnareObject>();
        lObj = lSnare.gameObject.GetComponent<SnareObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            aSnare.PlayOneShot(snare);
            aObj.FireSnare();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sSnare.PlayOneShot(snare);
            sObj.FireSnare();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            kSnare.PlayOneShot(snare);
            kObj.FireSnare();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            lSnare.PlayOneShot(snare);
            lObj.FireSnare();
        }
    }
}
