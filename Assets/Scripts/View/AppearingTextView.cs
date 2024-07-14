using UnityEngine;
using TMPro;
using Zenject;

public class AppearingTextView : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private AppearingText _appearingText;

    [Inject]
    public void Construct(AppearingText appearingText)
    {
        _appearingText = appearingText;
    }

    private void Start()
    {
        _appearingText.OnSimpleWord.AddListener(SetText);
        _appearingText.OnLastWord.AddListener(SetText);
    }

    private void SetText(int index) => _text.text = _appearingText.Words[index];
}