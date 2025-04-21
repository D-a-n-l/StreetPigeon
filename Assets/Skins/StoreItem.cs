using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class StoreItem : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    [SerializeField]
    private TMP_Text _name;

    [SerializeField]
    private SinglePlayerAnimation _playerAnimation;

    [Inject]
    private SettableSkin _settableSkin;

    public void Init(string nameSkin, string name, PresetAnimation animation)
    {
        _button.onClick.AddListener(() => _settableSkin.Set(nameSkin));

        _name.text = name;

        _playerAnimation.Init(animation);
    }
}