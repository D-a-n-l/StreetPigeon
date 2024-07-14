using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;

    [SerializeField]
    [Min(0.001f)]
    private float _amplitude;
    
    [SerializeField]
    [Min(0.001f)]
    private float _frequency; 
    
    [SerializeField]
    [Min(0.001f)]
    private float _timeShake;

    private CinemachineBasicMultiChannelPerlin _cameraMultiChannelPerlin;

    private static WaitForSecondsRealtime _waitForSecondsRealtime;

    private void Start()
    {
        _cameraMultiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _waitForSecondsRealtime = new WaitForSecondsRealtime(_timeShake);
    }

    public void ToShake() => StartCoroutine(Shake());

    private IEnumerator Shake()
    {
        _cameraMultiChannelPerlin.m_AmplitudeGain = _amplitude;
        _cameraMultiChannelPerlin.m_FrequencyGain = _frequency;

        yield return _waitForSecondsRealtime;

        _cameraMultiChannelPerlin.m_AmplitudeGain = 0;
        _cameraMultiChannelPerlin.m_FrequencyGain = 0;
    }
}