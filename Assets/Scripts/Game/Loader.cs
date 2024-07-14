using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public void LoadScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);

        Time.timeScale = 1;
    }

    public void Link(string link) => Application.OpenURL(link);
}