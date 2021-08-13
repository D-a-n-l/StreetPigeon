using UnityEngine;

public class SoundSFX : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private bool isMusicStart;

    private void Start() // под чем я это говно написал, позже исправить, я правда не знаю откуда это
    {
        if (isMusicStart)
        {
            PlaySoundEffect();
        }
    }

    public void PlaySoundEffect()
    {
        soundEffect.Play();
    }
}
