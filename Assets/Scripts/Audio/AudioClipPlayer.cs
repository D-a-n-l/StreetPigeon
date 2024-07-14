using UnityEngine;

public class AudioClipPlayer : MonoBehaviour
{
    public void PlayClipAtPoint(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }
}