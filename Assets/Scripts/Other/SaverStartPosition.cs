using UnityEngine;

public class SaverStartPosition : MonoBehaviour
{
    [SerializeField]
    private bool _isStart = true;

    [Space(10)]
    [SerializeField]
    private Enums.Direction _direction;

    [SerializeField]
    private Vector3 _offset;

    private Camera _mainCamera;//хз нужно или нет, просто мб использовать Camera.main

    private void Start()
    {
        if (_isStart == true)
            Set();
    }

    public void Set() 
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
    }
}