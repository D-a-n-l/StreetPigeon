using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerSingleton : MonoBehaviour
{
    public static AudioMixerSingleton Instance;
 
    [SerializeField] 
    private AudioMixer _mainAudioMixer;
 
    public AudioMixer AudioMixer { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);

        AudioMixer = _mainAudioMixer;
    }
}