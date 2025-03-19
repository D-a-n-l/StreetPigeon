using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public abstract class ButtonForMovingPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IUpdateSelectedHandler
{
    protected SettableSkin _settableSkin;

    protected MovingPlayer _player;

    protected Energy _energy;

    [Inject]
    public void Construct(SettableSkin settableSkin, Energy energy)
    {
        _settableSkin = settableSkin;

        _energy = energy;
    }

    private void Start()
    {
        if (_player == null)
            if (_settableSkin.Current != null && _settableSkin.Current.TryGetComponent(out MovingPlayer movingPlayer))
                _player = movingPlayer;
    }

    private void OnEnable()
    {
        _settableSkin.OnSetted += SetPlayer;
    }

    private void OnDisable()
    {
        _settableSkin.OnSetted += SetPlayer;
    }

    private void SetPlayer(GameObject go) => _player = go.GetComponent<MovingPlayer>();

    public abstract void OnPointerDown(PointerEventData eventData);

    public abstract void OnPointerUp(PointerEventData eventData);

    public abstract void OnUpdateSelected(BaseEventData eventData);
}