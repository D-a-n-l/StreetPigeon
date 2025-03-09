using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextTranslator : MonoBehaviour
{
    public string key;

    private TMP_Text tmpText;

    private void Start()
    {
        LangsList.langs.activatedTexts.Add(this);

        tmpText = GetComponent<TMP_Text>();

        ReTranslate();
    }

    private void OnDestroy()
    {
        LangsList.langs.activatedTexts.Remove(this);
    }

    public void ReTranslate()
    {
        tmpText.text = LangsList.GetWord(key);
    }
}