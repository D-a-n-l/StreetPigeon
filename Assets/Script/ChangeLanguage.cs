using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    private const int ID_RUS = 0;
    private const int ID_ENG = 1;

    public void ChangeLangRus()
    {
        LangsList.SetLanguage(ID_RUS, true);
    }

    public void ChangeLangEng()
    {
        LangsList.SetLanguage(ID_ENG, true);
    }
}
