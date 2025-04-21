using UnityEngine;
using Zenject;

public class Store : MonoBehaviour
{
    [SerializeField]
    private Transform _root;

    [SerializeField]
    private StoreItem _prefab;

    [Inject]
    private Skins _skins;

    private void Start()
    {
        foreach (var skin in _skins.List)
        {
            StoreItem storeItem = SingleAssetLoader.LoadWithInject(_prefab, _root);

            storeItem.Init(skin.Key, skin.Value.Name, skin.Value.PresetAnimation);
        }
    }
}