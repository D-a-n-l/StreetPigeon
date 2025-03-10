using UnityEngine;
using Cinemachine;
using System.Collections;
using Zenject;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;

    [Min(0.001f)]
    [SerializeField]
    private float _amplitude;

    [Min(0.001f)]
    [SerializeField]
    private float _frequency;

    [Min(0.001f)]
    [SerializeField]
    private float _timeShake;

    private CinemachineBasicMultiChannelPerlin _cameraMultiChannelPerlin;

    private WaitForSecondsRealtime _waitShake;

    [Inject]
    private Health _health;

    private void Start()
    {
        _cameraMultiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _waitShake = new WaitForSecondsRealtime(_timeShake);

        _health.OnDecreased += Shake;
    }

    private void OnDisable()
    {
        _health.OnDecreased -= Shake;
    }

    public void Shake() => StartCoroutine(ShakeCo());

    private IEnumerator ShakeCo()
    {
        _cameraMultiChannelPerlin.m_AmplitudeGain = _amplitude;
        _cameraMultiChannelPerlin.m_FrequencyGain = _frequency;

        yield return _waitShake;

        _cameraMultiChannelPerlin.m_AmplitudeGain = 0;
        _cameraMultiChannelPerlin.m_FrequencyGain = 0;
    }
}