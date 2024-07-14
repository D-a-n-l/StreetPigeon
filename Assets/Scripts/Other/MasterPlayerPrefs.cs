using UnityEngine;

public class MasterPlayerPrefs
{
    public const string HIGH_SCORE = "highScore";

    public const string VOLUME_MUSIC = "MusicVolume";

    public const string VOLUME_SOUND = "SoundVolume";

    public const string VOLUME_UI = "SoundUIVolume";

    public const string LEARNING_SCENE = "LearningScene";

    public static string SetKey(Enums.KeyPlayerPrefs key)
    {
        if (key == Enums.KeyPlayerPrefs.highScore)
            return HIGH_SCORE;
        else if (key == Enums.KeyPlayerPrefs.sound)
            return VOLUME_SOUND;
        else if (key == Enums.KeyPlayerPrefs.music)
            return VOLUME_MUSIC;
        else if (key == Enums.KeyPlayerPrefs.ui)
            return VOLUME_UI;
        else
            return LEARNING_SCENE;
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static float GetFloat(string key, float defaultValue)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    public static int GetInt(string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public static void ResetKet(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}