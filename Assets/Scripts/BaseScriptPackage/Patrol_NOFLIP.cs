using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_NOFLIP : MonoBehaviour {
    public Transform pointA;
    public Transform pointB;
    bool goToPointA = true;
    public float speed = 0.3f;

    Vector3 thisPosition;


    private void Start()
    {
        thisPosition = transform.position;
        CalculateClosestPoint();
    }
    // Update is called once per frame
    void Update()
    {
        thisPosition = transform.position;
        if (!goToPointA)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed);
            if (thisPosition.Equals(pointB.position))
            {
                goToPointA = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed);
            if (thisPosition.Equals(pointA.position))
            {
                goToPointA = false;
            }
        }
    }
    void CalculateClosestPoint()
    {
        float distA = Vector3.Distance(thisPosition, pointA.transform.position);
        float distB = Vector3.Distance(thisPosition, pointB.transform.position);

        if (distA >= distB)
        {
            goToPointA = false;
        }
        else
        {
            goToPointA = true;
        }

    }
}