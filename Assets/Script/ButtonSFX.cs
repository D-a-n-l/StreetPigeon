using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffect;

    public void PlaySoundEffect()
    {
        soundEffect.Play();
    }
}
