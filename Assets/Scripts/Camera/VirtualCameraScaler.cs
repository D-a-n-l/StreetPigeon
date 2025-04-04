using UnityEngine;
using Cinemachine;

public class VirtualCameraScaler : MonoBehaviour
{
    [SerializeField]
    private Vector2 _referenceResolution = new Vector2(1920, 1080);

    [SerializeField]
    private WorkingMode _mode = WorkingMode.ConstantWidth;

    [SerializeField]
    private float _matchWidthOrHeight = 0.5f;

    private CinemachineVirtualCamera _componentCamera;

    private float _targetAspect;
    private float _cameraZoom = 1;

    private float _initialSize;

    private float _previousUpdateAspect;
    private WorkingMode _previousUpdateMode;
    private float _previousUpdateMatch;

    public float HorizontalSize => _initialSize * _targetAspect;

    public float CameraZoom
    {
        get => _cameraZoom;
        set
        {
            _cameraZoom = value;
            UpdateCamera();
        }
    }

    public enum WorkingMode
    {
        ConstantHeight,
        ConstantWidth,
        MatchWidthOrHeight,
        Expand,
        Shrink
    }

    private void Awake()
    {
        _componentCamera = GetComponent<CinemachineVirtualCamera>();
        _initialSize = _componentCamera.m_Lens.OrthographicSize;

        _targetAspect = _referenceResolution.x / _referenceResolution.y;

        UpdateCamera();
    }

    //private void Update()
    //{
    //    if (!Mathf.Approximately(_previousUpdateAspect, _componentCamera.m_Lens.Aspect) ||
    //        _previousUpdateMode != _mode ||
    //        !Mathf.Approximately(_previousUpdateMatch, _matchWidthOrHeight))
    //    {
    //        UpdateCamera();

    //        _previousUpdateAspect = _componentCamera.m_Lens.Aspect;
    //        _previousUpdateMode = _mode;
    //        _previousUpdateMatch = _matchWidthOrHeight;
    //    }
    //}

    private void UpdateCamera()
    {
        UpdateOrtho();
    }

    private void UpdateOrtho()
    {
        switch (_mode)
        {
            case WorkingMode.ConstantHeight:
                _componentCamera.m_Lens.OrthographicSize = _initialSize / _cameraZoom;
                break;

            case WorkingMode.ConstantWidth:
                _componentCamera.m_Lens.OrthographicSize = _initialSize * (_targetAspect / _componentCamera.m_Lens.Aspect) / _cameraZoom;
                break;

            case WorkingMode.MatchWidthOrHeight:
                float vSize = _initialSize;
                float hSize = _initialSize * (_targetAspect / _componentCamera.m_Lens.Aspect);
                float vLog = Mathf.Log(vSize, 2);
                float hLog = Mathf.Log(hSize, 2);
                float logWeightedAverage = Mathf.Lerp(hLog, vLog, _matchWidthOrHeight);
                _componentCamera.m_Lens.OrthographicSize = Mathf.Pow(2, logWeightedAverage) / _cameraZoom;
                break;

            case WorkingMode.Expand:
                if (_targetAspect > _componentCamera.m_Lens.OrthographicSize)
                {
                    _componentCamera.m_Lens.OrthographicSize = _initialSize * (_targetAspect / _componentCamera.m_Lens.Aspect) / _cameraZoom;
                }
                else
                {
                    _componentCamera.m_Lens.OrthographicSize = _initialSize / _cameraZoom;
                }

                break;

            case WorkingMode.Shrink:
                if (_targetAspect < _componentCamera.m_Lens.Aspect)
                {
                    _componentCamera.m_Lens.OrthographicSize = _initialSize * (_targetAspect / _componentCamera.m_Lens.Aspect) / _cameraZoom;
                }
                else
                {
                    _componentCamera.m_Lens.OrthographicSize = _initialSize / _cameraZoom;
                }

                break;
            default:
                Debug.LogError("Incorrect CameraScaler.Mode: " + _mode);
                break;
        }
    }
}