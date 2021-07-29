using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 startPosition = Vector2.zero;
    private float direction = 0f;

    public static event Action<float> OnMove;

    private void Update()
    {
#if UNITY_EDITOR
        OnMove?.Invoke(Input.GetAxisRaw("Vertical"));
#endif
#if UNITY_ANDROID
        GetTouchInput();
#endif
    }

    private void GetTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    direction = touch.position.y > startPosition.y ? 1f : -1f;
                    break;
                default:
                    startPosition = touch.position;
                    direction = 0f;
                    break;
            }
            OnMove?.Invoke(direction);
        }
    }
}
