using UnityEngine;
using Zenject;

public class RestartPanel : MonoBehaviour
{
    [Inject]
    private Bootstrap _bootstrap;

    private bool _isPressed = false;

    public void SetPressed(bool value) => _isPressed = value;

    public async void OnClosed()
    {
        if (_isPressed == true)
        {
            await _bootstrap.RestartGame();
        }
    }
}