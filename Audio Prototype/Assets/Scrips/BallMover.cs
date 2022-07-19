using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    public Vector3 target;
    public Vector3 startPosition;

    float startTime, journeyLength;

    public void LateStart()
    {
        transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        startPosition = transform.position;
        startTime = Time.time;
        target.y = 0;
        journeyLength = Vector3.Distance(startPosition, target);
    }

    void Update()
    { 
        float distCovered = (Time.time - startTime) * 2f;

        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startPosition, target, fractionOfJourney);
        
        if (fractionOfJourney >= 1) Destroy(gameObject);
    }
}
