using UnityEngine;
using UnityEngine.AddressableAssets;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private bool _isInit = true;

    [SerializeField]
    private AssetReference _assetReference;

    [SerializeField]
    private Transform _positionRoot;

    private GameObject _cashedObject = null;

    private void Awake()
    {
        if (_isInit == true)
            InitObject();
    }

    public async void Spawn()
    {
        var handle  = LocalAssetLoader.LoadInternalSingle(_assetReference, _positionRoot);

        _cashedObject = await handle;
    }

    public async void SpawnWithEvent()
    {
        EnableEvent.CallEnabled(true);

        var handle  = LocalAssetLoader.LoadInternalSingle(_assetReference, _positionRoot);

        _cashedObject = await handle;
    }

    public void Despawn()
    {
        LocalAssetLoader.UnloadInternalSingle(_cashedObject);
    }

    public void DespawnSingle(GameObject gameobject)
    {
        LocalAssetLoader.UnloadInternalSingle(gameobject);
    }

    public void DespawnSingleWithEvent(GameObject gameobject)
    {
        EnableEvent.CallEnabled(false);

        LocalAssetLoader.UnloadInternalSingle(gameobject);
    }

    public async void InitObject()
    {
        var handle  = LocalAssetLoader.LoadInternalSingle(_assetReference, _positionRoot);

        _cashedObject = await handle;

        Despawn();
    }
}