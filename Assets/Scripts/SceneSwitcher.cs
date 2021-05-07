using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("LD_Level_1");
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("LD_Title_Screen");
    }
    public void OpenAboutScreen()
    {
        SceneManager.LoadScene("LD_About_Screen");
    }


}
