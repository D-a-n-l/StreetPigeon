using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickableAction : MonoBehaviour, IPointerClickHandler
{
    [Min(1)]
    [SerializeField]
    private int _countTapToAction = 1;

    private int _currentCountTap = 0;

    [SerializeField]
    private UnityEvent OnCompleted;

    public void OnPointerClick(PointerEventData eventData)
    {
        _currentCountTap++;

        if (_currentCountTap < _countTapToAction)
            return;

        Zeroing();

        OnCompleted?.Invoke();
    }

    public void Zeroing()
    {
        _currentCountTap = 0;
    }
}