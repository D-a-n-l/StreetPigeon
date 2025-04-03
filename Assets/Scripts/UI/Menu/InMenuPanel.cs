using UnityEngine;
using Zenject;

public class InMenuPanel : MonoBehaviour
{
    [Inject]
    private Bootstrap _bootstrap;

    private bool _isPressed = false;

    public void SetPressed(bool value) => _isPressed = value;

    public void OnClosed()
    {
        if (GameState.IsGame == true && _isPressed == true)
        {
            _bootstrap.InMenu();

            _bootstrap.ButtonStart.StartStepWithEvent(true);

            GameState.Set(false);
        }
    }
}