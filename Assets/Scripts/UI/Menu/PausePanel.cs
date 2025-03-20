using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private float _currentTimeScale;

    private void Start()
    {
        _currentTimeScale = Time.timeScale;

        if (GameState.IsGame == true)
            Time.timeScale = 0;
    }

    public void OnClosed()
    {
        Time.timeScale = _currentTimeScale;
    }
}