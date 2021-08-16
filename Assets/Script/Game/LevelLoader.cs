using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const short GAME_SCENE = 1; 
    private const short MENU_SCENE = 0; 
    private const short LEARNING_SCENE = 2; 
    
    [SerializeField] private bool isStartLoader = false;
    [SerializeField] private float timeLoad = 0.1f;
    
    public void PlayGame()
    {
        isStartLoader = MasterPlayerPrefs.GetLearningScnene() == 1;
        if (!isStartLoader)
        {
            MasterPlayerPrefs.SetLearningScnene(1);
            SceneManager.LoadScene(LEARNING_SCENE);
        }
        else
        {
            SceneManager.LoadScene(GAME_SCENE);
        }
    }

    public void MenuLoad()
    {
        SceneManager.LoadScene(MENU_SCENE);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LearnignLoad()
    {
        SceneManager.LoadScene(LEARNING_SCENE);
    }

    public void LinkChannal()
    {
        Application.OpenURL("https://t.me/heavy_ascent");
    }
}
