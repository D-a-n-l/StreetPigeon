using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private const float SizeX = 2960.0f;    //1920.0f;
    private const float SizeY = 1440.0f;    //1080.0f;
    private const float HalfSize = 200.0f;  // Половина высоты в px

    private float targetSizeX = 0f;
    private float targetSizeY = 0f;

    [SerializeField] private bool isHorizontal = true;

    private void Awake()
    {
        targetSizeX = isHorizontal ? SizeX : SizeY;
        targetSizeY = isHorizontal ? SizeY : SizeX;
        CameraResize();
    }

    private void CameraResize()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height; // Соотношение сторон текущаего разрешения
        float targetRatio = targetSizeX / targetSizeY; // Соотношение сторон целевого разрешения

        if (screenRatio >= targetRatio)
        {
            Resize();
        }
        else
        {
            float differentSize = targetRatio / screenRatio;
            Resize(differentSize);
        }
    }

    private void Resize(float different = 1.0f)
    {
        Camera.main.orthographicSize = targetSizeY / HalfSize * different;
    }
}
