using UnityEngine;

public class Scrolling : MonoBehaviour
{
    [SerializeField]
    [Min(0.001f)]
    private float _parallaxSpeed = 8f;

    [SerializeField]
    [Min(0.001f)]
    private float _backgroundSize;

    private Transform _cameraTransform;

    private Transform[] _layers;

    private float _viewZone;

    private int _leftIndex;

    private int _rightIndex;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;

        _viewZone = Camera.main.orthographicSize;

        _layers = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _layers[i] = transform.GetChild(i);
        }

        _leftIndex = 0;

        _rightIndex = _layers.Length - 1;
    }

    private void Update()
    { 
        transform.Translate(Vector2.left * _parallaxSpeed * Time.deltaTime);

        if (_cameraTransform.position.x < (_layers[_leftIndex].transform.position.x + _viewZone))
            ToScroll(false);
        else if (_cameraTransform.position.x > (_layers[_rightIndex].transform.position.x - _viewZone))
            ToScroll(true);
    }

    private void ToScroll(bool isLeft)
    {
        if (isLeft == true)
        {
            _layers[_leftIndex].position = Vector3.right * (_layers[_rightIndex].position.x + _backgroundSize);

            _rightIndex = _leftIndex;

            _leftIndex++;

            if (_leftIndex == _layers.Length)
                _leftIndex = 0;
        }
        else
        {
            _layers[_rightIndex].position = Vector3.right * (_layers[_leftIndex].position.x - _backgroundSize);

            _leftIndex = _rightIndex;
        
            _rightIndex--;

            if (_rightIndex < 0)
                _rightIndex = _layers.Length - 1;
        }
    }
}