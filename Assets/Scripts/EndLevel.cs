using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private GameManager_SideScroller gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager_SideScroller>();

    }


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (gameManager.score == 150)
            {
                SceneManager.LoadScene("LD_Title_Screen");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
