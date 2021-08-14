using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const short GAME_SCENE = 1; 
    private const short MENU_SCENE = 0; 
    private const short LEARNING_SCENE = 2; 
    
    public void PlayGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
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
}
