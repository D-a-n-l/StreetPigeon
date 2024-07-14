using UnityEngine;

public class ChangeLanguage : MonoBehaviour
{
    private void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
        {
            Set(0);
        }
        else
        {
            Set(1);
        }
    }

    public void Set(int id)
    {
        LangsList.SetLanguage(id, true);
    }
}