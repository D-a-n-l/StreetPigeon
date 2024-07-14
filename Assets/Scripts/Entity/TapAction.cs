using UnityEngine;
using UnityEngine.Events;

public class TapAction : MonoBehaviour
{
    [SerializeField]
    private int _countTapToAction;

    private int _currentCountTap = 0;

    public UnityEvent OnComplete;

    public void OnMouseDown()
    {
        _currentCountTap++;

        if (_currentCountTap < _countTapToAction)
            return;

        OnComplete.Invoke();
    }
}