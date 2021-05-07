using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public Transform pointA;
    public Transform pointB;
    bool goToPointA = true;
    [Tooltip("Set true if your character is always facing the wrong way")]
    public bool flipFix = true;
    public float speed = 0.3f;
    Vector3 thisPosition;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        thisPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        CalculateClosestPoint();
    }
    // Update is called once per frame
    void Update()
    {
        thisPosition = transform.position;
        if (!goToPointA)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed);
            //Debug.Log("Going to B");
            if (thisPosition.Equals(pointB.position))
            {
                //Debug.Log("At B");
                goToPointA = true;
                if (flipFix)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed);
            //Debug.Log("Going to A");
            if (thisPosition.Equals(pointA.position))
            {
                //Debug.Log("At A");
                goToPointA = false;
                if (flipFix)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }

    void CalculateClosestPoint()
    {
        float distA = Vector3.Distance(thisPosition, pointA.transform.position);
        Debug.Log($"A: {distA}");
        float distB = Vector3.Distance(thisPosition, pointB.transform.position);
        Debug.Log($"B: {distB}");

        if (distA >= distB)
        {
            goToPointA = false;
        }
        else
        {
            goToPointA = true;
        }
        Debug.Log($"Point A?: {goToPointA}");

    }
}