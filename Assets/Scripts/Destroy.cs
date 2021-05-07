using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void DestroyAllObjects()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        for(int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i]);
        }
    }
}
