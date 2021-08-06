using UnityEngine;

public class MasterPlayerPrefs : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "highScore";

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
}
