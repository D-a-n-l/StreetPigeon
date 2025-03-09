using UnityEngine;
using UnityEngine.Events;

public class TapAction : MonoBehaviour
{
    [SerializeField]
    [Min(1)]
    private int _countTapToAction;

    private int _currentCountTap = 0;

    public UnityEvent OnComplete;

    private void OnMouseDown()
    {
        _currentCountTap++;

        if (_currentCountTap < _countTapToAction)
            return;

        OnComplete.Invoke();
    }
}