using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffect;

    private void Start()
    {
        soundEffect.Play();
    }
}
