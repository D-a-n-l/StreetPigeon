using UnityEngine;

public class FPS : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
    }
}