using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        EnableEvent.Enabled.AddListener(Switch);
    }

    private void Switch(bool value)
    {
        _button.enabled = !value; 
    }
}