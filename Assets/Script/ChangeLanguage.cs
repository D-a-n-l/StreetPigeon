using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    private const int ID_RUS = 0;
    private const int ID_ENG = 1;

    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
        {
            LangsList.SetLanguage(ID_RUS, true);
        }
        else
        {
            LangsList.SetLanguage(ID_ENG, true);
        }
    }

    public void ChangeLangRus()
    {
        LangsList.SetLanguage(ID_RUS, true);
    }

    public void ChangeLangEng()
    {
        LangsList.SetLanguage(ID_ENG, true);
    }
}
