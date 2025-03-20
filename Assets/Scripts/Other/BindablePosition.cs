using UnityEngine;

public class BindablePosition : MonoBehaviour
{
    [SerializeField]
    private bool _isStart = true;

    [Space(10)]
    [SerializeField]
    private BindablePositionPreset _preset;

    private void Start()
    {
        if (_isStart == true)
            Set(_preset, transform);
    }

    public static void Set(BindablePositionPreset preset, Transform go) 
    {
        Vector3 worldPoint;

        switch (preset.Direction)
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

        worldPoint = new Vector3(worldPoint.x, worldPoint.y, 0);

        go.position = worldPoint + preset.Offset;
    }
}

[System.Serializable]
public class BindablePositionPreset
{
    public Enums.Direction Direction;

    public Vector3 Offset;

    public BindablePositionPreset(Enums.Direction direction, Vector3 offset)
    {
        Direction = direction;

        Offset = offset;
    }
}