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
        if (GameState.State == true && _isPressed == true)
        {
            _bootstrap.pigANim.StartStepWithEvent(true);

            _bootstrap.SpawbGolube();

            GameState.Set(false);
        }

        Debug.Log("Menu Panel " + Time.timeScale);
    }
}