using UnityEngine;
using Cinemachine;

public class ControllerCameraSize : MonoBehaviour
{
    [SerializeField] 
    private Vector2 _defaultResolution = new(1920, 1080);

    [SerializeField, Range(0, 1)]
    private float _widthOrHeight = .5f;

    private Camera _mainCamera;

    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private float _initialSize;

    private float _targetAspect;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _cinemachineVirtualCamera ??= GetComponent<CinemachineVirtualCamera>();

        _initialSize = _mainCamera.orthographicSize;

        _targetAspect = _defaultResolution.x / _defaultResolution.y;

        float constantWidthSize = _initialSize * (_targetAspect / _mainCamera.aspect);

        if (_cinemachineVirtualCamera == null)
            _mainCamera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, _widthOrHeight);
        else
            _cinemachineVirtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, _widthOrHeight);
    }
}