using UnityEngine;
using NaughtyAttributes;

public class AudioSourcePlayer : MonoBehaviour
{
    [SerializeField]
    private bool _isLoadingAsset = false;

    [SerializeField]
    [HideIf(nameof(_isLoadingAsset))]
    private AudioSource _audioSource;

    [SerializeField]
    private Vector2 _randomPitch = new(1f, 1f);

    private void Start()
    {
        if (_isLoadingAsset == true)
            _audioSource = AudioSourceSingleton.Instance.AudioSource;
        else
            _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _audioSource.pitch = Random.Range(_randomPitch.x, _randomPitch.y);

        _audioSource.Play();
    }
}