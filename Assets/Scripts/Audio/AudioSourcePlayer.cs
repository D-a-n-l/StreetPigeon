using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourcePlayer : MonoBehaviour
{
    [SerializeField]
    private Vector2 _randomPitch = new(1f, 1f);

    private AudioSource _source;

    private void Start()
    {
        _source ??= GetComponent<AudioSource>();
    }

    public void Play()
    {
        _source.pitch = Random.Range(_randomPitch.x, _randomPitch.y);

        _source.Play();
    }
}