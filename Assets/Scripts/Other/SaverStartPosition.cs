using UnityEngine;

public class SaverStartPosition : MonoBehaviour
{
    [SerializeField] 
    private Enums.Direction _direction;

    [SerializeField]
    private Vector3 _offset;

    private Camera _mainCamera;

    public Vector3 SavedPosition { get; private set; }

    private void Start() 
    {   
        _mainCamera = Camera.main;

        Vector3 worldPoint;

        if (_direction == Enums.Direction.Top)
            worldPoint = _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height));
        else if (_direction == Enums.Direction.Right) 
            worldPoint = _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
        else if (_direction == Enums.Direction.Bottom)
            worldPoint = _mainCamera.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
        else
            worldPoint = _mainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height / 2));
        
        transform.position = worldPoint + _offset;

        SavedPosition = transform.position;
    }
}