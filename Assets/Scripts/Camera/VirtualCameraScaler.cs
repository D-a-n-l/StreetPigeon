using UnityEngine;
using Cinemachine;

public class VirtualCameraScaler : MonoBehaviour
{
    [SerializeField]
    private Vector2 ReferenceResolution = new Vector2(1920, 1080);

    [SerializeField]
    private WorkingMode Mode = WorkingMode.ConstantWidth;

    [SerializeField]
    private float MatchWidthOrHeight = 0.5f;

    private CinemachineVirtualCamera componentCamera;

    private float targetAspect;
    private float cameraZoom = 1;

    private float initialSize;

    private float previousUpdateAspect;
    private WorkingMode previousUpdateMode;
    private float previousUpdateMatch;

    public float HorizontalSize => initialSize * targetAspect;

    public float CameraZoom
    {
        get => cameraZoom;
        set
        {
            cameraZoom = value;
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
        componentCamera = GetComponent<CinemachineVirtualCamera>();
        initialSize = componentCamera.m_Lens.OrthographicSize;

        targetAspect = ReferenceResolution.x / ReferenceResolution.y;
    }

    private void Update()
    {
        if (!Mathf.Approximately(previousUpdateAspect, componentCamera.m_Lens.Aspect) ||
            previousUpdateMode != Mode ||
            !Mathf.Approximately(previousUpdateMatch, MatchWidthOrHeight))
        {
            UpdateCamera();

            previousUpdateAspect = componentCamera.m_Lens.Aspect;
            previousUpdateMode = Mode;
            previousUpdateMatch = MatchWidthOrHeight;
        }
    }

    private void UpdateCamera()
    {
        UpdateOrtho();
    }

    private void UpdateOrtho()
    {
        switch (Mode)
        {
            case WorkingMode.ConstantHeight:
                componentCamera.m_Lens.OrthographicSize = initialSize / cameraZoom;
                break;

            case WorkingMode.ConstantWidth:
                componentCamera.m_Lens.OrthographicSize = initialSize * (targetAspect / componentCamera.m_Lens.Aspect) / cameraZoom;
                break;

            case WorkingMode.MatchWidthOrHeight:
                float vSize = initialSize;
                float hSize = initialSize * (targetAspect / componentCamera.m_Lens.Aspect);
                float vLog = Mathf.Log(vSize, 2);
                float hLog = Mathf.Log(hSize, 2);
                float logWeightedAverage = Mathf.Lerp(hLog, vLog, MatchWidthOrHeight);
                componentCamera.m_Lens.OrthographicSize = Mathf.Pow(2, logWeightedAverage) / cameraZoom;
                break;

            case WorkingMode.Expand:
                if (targetAspect > componentCamera.m_Lens.OrthographicSize)
                {
                    componentCamera.m_Lens.OrthographicSize = initialSize * (targetAspect / componentCamera.m_Lens.Aspect) / cameraZoom;
                }
                else
                {
                    componentCamera.m_Lens.OrthographicSize = initialSize / cameraZoom;
                }

                break;

            case WorkingMode.Shrink:
                if (targetAspect < componentCamera.m_Lens.Aspect)
                {
                    componentCamera.m_Lens.OrthographicSize = initialSize * (targetAspect / componentCamera.m_Lens.Aspect) / cameraZoom;
                }
                else
                {
                    componentCamera.m_Lens.OrthographicSize = initialSize / cameraZoom;
                }

                break;
            default:
                Debug.LogError("Incorrect CameraScaler.Mode: " + Mode);
                break;
        }
    }
}