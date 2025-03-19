using UnityEngine.EventSystems;

public class ButtonFall : ButtonForMovingPlayer
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        _energy.OnPressed(true);

        _player.OnPressed(true);

        _player.ButtonDown(-5);

        _player.Rotate(-40);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _energy.OnPressed(false);

        _player.OnPressed(false);

        _player.ButtonUp(-2);
    }

    public override void OnUpdateSelected(BaseEventData eventData)
    {
        _energy.Decrease(0.15f);

        _player.PressedButton(-5);
    }
}