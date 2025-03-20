using UnityEngine;

public class BindablePosition : MonoBehaviour
{
    [SerializeField]
    private bool _isStart = true;

    [Space(10)]
    [SerializeField]
    private Enums.Direction _direction;

    [SerializeField]
    private Vector3 _offset;

    private void Start()
    {
        if (_isStart == true)
            Set(_direction, _offset, transform);
    }

    public static void Set(Enums.Direction direction, Vector3 offset, Transform go) 
    {
        Vector3 worldPoint;

        switch (direction)
        {
            case Enums.Direction.Top:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                break;
            case Enums.Direction.TopRight:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
                break;
            case Enums.Direction.TopLeft:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
                break;
            case Enums.Direction.Bottom:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
                break;
            case Enums.Direction.BottomRight:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
                break;
            case Enums.Direction.BottomLet:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
                break;
            case Enums.Direction.Right:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
                break;
            case Enums.Direction.Left:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
                break;
            default:
                worldPoint = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
                break;
        }

        go.position = worldPoint + offset;
    }
}