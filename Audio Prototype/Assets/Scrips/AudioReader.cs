using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReader : MonoBehaviour
{
    public AudioSource audioSource;
    public int index;
    public float time;
    public TimingStruct[] timings;
    public GameObject ball;
    public bool done;

    public Vector3[] spawnpositions;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(2);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (index > timings.Length - 1) done = true;

        if (!done && time > timings[index].time)
        {
            // spawn audio block
            GameObject ballObj = Instantiate(ball, spawnpositions[timings[index].spawnPos], Quaternion.identity) as GameObject;
            ballObj.GetComponent<BallMover>().target = spawnpositions[timings[index].spawnPos];
            ballObj.GetComponent<BallMover>().LateStart();
            timings[index].spawned = true;
            if (timings[index].spawned)
            {
                index++;
            }
        }
    }
}

[Serializable]
public class TimingStruct
{
    public float time = 0;
    public int spawnPos = 0; // A S K L -> 0 1 2 3 
    public bool spawned = false;
}
