using UnityEngine;

public class AudioSourceSingleton : MonoBehaviour
{
    public static AudioSourceSingleton Instance;
 
    [SerializeField] 
    private AudioSource _audioSource;
 
    public AudioSource AudioSource { get; private set; }

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

        AudioSource = _audioSource;
    }
}