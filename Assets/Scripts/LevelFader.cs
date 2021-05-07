using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFader : MonoBehaviour
{
    public Animator animator;

    
    public void FadeToLevel (int levelIndex)
    {
         //levelToLoad = levelIndex;
         animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
      
    }
}
