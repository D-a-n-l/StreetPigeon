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

    [Inject]
    private Skins _skins;

    public GameObject Current { get; private set; }

    public Action<GameObject> OnSetted;

    private void Start()
    {
        Set(_baseSkin);
    }

    public async void Set(string name)
    {
        if (Current != null)
        {
            _loader.Unload();

            Current = null;
        }

        var handle = _loader.LoadWithInject(_skins.List[name].Prefab, _root);

        Current = await handle;

        Current.transform.SetLocalPositionAndRotation(_skins.List[name].Position, Quaternion.identity);
        Current.transform.localScale = _skins.List[name].Scale;

        OnSetted?.Invoke(Current);
    }
}