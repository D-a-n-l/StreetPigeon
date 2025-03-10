using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private bool _isEvent = false;

    private void Start()
    {
        if (_isEvent == true)
            EnableEvent.Enabled.AddListener(EnableValue);
    }

    public void Enable()
    {
        _canvas.enabled = !_canvas.enabled;

        Time.timeScale = _canvas.enabled ? 0 : 1;
    }

    public void EnableValue(bool value)
    {
        _canvas.enabled = value;

        Time.timeScale = value ? 0 : 1;
    }
}