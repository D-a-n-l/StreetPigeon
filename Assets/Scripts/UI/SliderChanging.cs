using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderChanging : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private Enums.KeyPlayerPrefs _key;

    [SerializeField]
    [Min(0.0001f)]
    private float _minValue = 0.0001f;

    [SerializeField]
    [Min(0.01f)]
    private float _defaultValue = 1f;

    private AudioMixer _audioMixer;

    private void Start()
    {
        _audioMixer = AudioMixerSingleton.Instance.AudioMixer;

        _slider.minValue = _minValue;
        
        _slider.value = MasterPlayerPrefs.GetFloat(MasterPlayerPrefs.SetKey(_key), _defaultValue);
    }

    public void ChangeVolume(float volume)
    {
        _audioMixer.SetFloat(MasterPlayerPrefs.SetKey(_key), Mathf.Log10(volume) * 20);

        MasterPlayerPrefs.SetFloat(MasterPlayerPrefs.SetKey(_key), volume);
    }
}