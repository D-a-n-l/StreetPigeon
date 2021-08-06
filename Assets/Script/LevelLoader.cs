using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private short gameScene = 1; 
    [SerializeField] private short menuScene = 0; 
    
    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void MenuLoad()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
