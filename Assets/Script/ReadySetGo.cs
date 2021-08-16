using System.Collections;
using UnityEngine;
using TMPro;

public class ReadySetGo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textReady;
    [SerializeField] private AudioClip bass;
    [SerializeField] private AudioClip Airhorn;
    [SerializeField] private float waitTime = 2f;

    private string[] textReadySetGo = new string[] {"READY", "SET", "GO"};
    private int index = 0;

    IEnumerator Start()
    {
        while (index < 3)
        {
            yield return new WaitForSeconds(waitTime);
            AudioSX(bass);
            index++;
            Debug.Log(index);
            
            if (index == 2)
            {
                yield return new WaitForSeconds(waitTime);
                AudioSX(Airhorn);
                yield return new WaitForSeconds(waitTime);
                textReady.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void AudioSX(AudioClip clip)
    {
        textReady.text = textReadySetGo[index];
        AudioSource.PlayClipAtPoint(clip, transform.position, MasterPlayerPrefs.GetVolumeMaster());
    }
}
