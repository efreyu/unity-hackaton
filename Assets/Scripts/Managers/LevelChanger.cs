using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private string _levelToLoad;
    /*private void Awake()
    {
        GameManager.Instance.LevelChanger = this;
    }*/
//    public void FadeToLevel(int levelIndex)
//    {
//        Time.timeScale = 1f;
//        _levelToLoad = levelIndex;
//        animator.SetTrigger("FadeOut");
//        GameManager.Instance.CurrentScore = 0;
//        GameManager.Instance.currentScoreObj.text = "Current Score: 0";
//        GameManager.Instance.EndGame(true);
//    }

    public void LoadLevel(string levelName)
    {
        _levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
        Debug.Log(levelName);
    }
    
    public void OnFadeComplete()
    {
        Debug.Log("OnFadeComplete");
        SceneManager.LoadScene(_levelToLoad);
//        SceneManager.LoadScene(scenename);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}