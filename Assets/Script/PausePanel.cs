using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixer;
    private GameSession gameSession;

    private void Start()
    {
        GetComponentInChildren<Toggle>().isOn = MasterPlayerPrefs.GetVolumeToggleMusic() == 1;
        GetComponentInChildren<Slider>().value = MasterPlayerPrefs.GetVolumeMaster();
    }

    public void OnEneble()
    {
        Time.timeScale = 0f;
    }

    public void OnDisble()
    {
        Time.timeScale = FindObjectOfType<GameSession>().VelocityGame();
    }

    public void ToggleMusic(bool enabled)
    {
        if(enabled)
        {
            mixer.audioMixer.SetFloat("MusicVolume", 0f);
        }
        else
        {
            mixer.audioMixer.SetFloat("MusicVolume", -80f);
        }

        MasterPlayerPrefs.SetVolumeToggleMusic(enabled ? 1 : 0);
    }

    public void ChangeVolume(float volume)
    {
        mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80f, 0f, volume));
        MasterPlayerPrefs.SetVolumeMaster(volume);
    }
}
