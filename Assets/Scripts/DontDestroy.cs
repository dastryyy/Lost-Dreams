using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        Debug.Log(objs.Length);
        if (objs.Length > 1 | SceneManager.GetActiveScene().name == "LD_Level_1")
        {
            Debug.Log("Switching songs");
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        
    }
}
