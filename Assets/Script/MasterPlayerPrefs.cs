using UnityEngine;

public class MasterPlayerPrefs : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "highScore";
    private const string VOLUME_MASTER = "MasterVolume";
    private const string VOLUME_TOGGLE_MUSIC = "MusicVolume";

    public static void SetHighScoreMaster(int highScore)
    {
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
    }

    public static int GetHighScoreMaster()
    {
        if (PlayerPrefs.HasKey(HIGH_SCORE_KEY))
        {
            return PlayerPrefs.GetInt(HIGH_SCORE_KEY);   
        }
        else
        {
            return 0;
        }
    }

    public static void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(HIGH_SCORE_KEY);
    }

    public static void SetVolumeMaster(float volume)
    {
        PlayerPrefs.SetFloat(VOLUME_MASTER, volume);
    }

    public static float GetVolumeMaster()
    {
        return PlayerPrefs.GetFloat(VOLUME_MASTER, 1f);
    }

    public static void SetVolumeToggleMusic(int enabled)
    {
        PlayerPrefs.SetInt(VOLUME_TOGGLE_MUSIC, enabled);
    }

    public static int GetVolumeToggleMusic()
    {
        return PlayerPrefs.GetInt(VOLUME_TOGGLE_MUSIC, 1);
    }
}
