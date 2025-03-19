using System;
using UnityEngine;
using Zenject;

public class SettableSkin : MonoBehaviour
{
    [SerializeField]
    private Transform _root;

    [SerializeField]
    private string _baseSkin;

    private SingleAssetLoader _loader = new SingleAssetLoader();

    private string _lastNameSkin;

    [Inject]
    private Skins _skins;

    public GameObject Current { get; private set; }

    public Action<GameObject> OnSetted;

    private void Start()
    {
        Set(_baseSkin);
    }

    public void SetLast()
    {
        SetWithDelay(_lastNameSkin);
    }

    public async void Set(string name)
    {
        if (Current != null)
        {
            _loader.Unload();

            Current = null;
        }

        _lastNameSkin = name;

        var handle = _loader.LoadWithInject(_skins.List[name].Prefab, _root);

        Current = await handle;

        Current.transform.SetLocalPositionAndRotation(_skins.List[name].Position, Quaternion.identity);
        Current.transform.localScale = _skins.List[name].Scale;

        OnSetted?.Invoke(Current);
    }

    public async void SetWithDelay(string name)
    {
        if (Current != null)
        {
            _loader.UnloadWithDelay();

            Current = null;
        }

        _lastNameSkin = name;

        var handle = _loader.LoadWithInject(_skins.List[name].Prefab, _root);

        Current = await handle;

        Current.transform.SetLocalPositionAndRotation(_skins.List[name].Position, Quaternion.identity);
        Current.transform.localScale = _skins.List[name].Scale;

        OnSetted?.Invoke(Current);
    }
}