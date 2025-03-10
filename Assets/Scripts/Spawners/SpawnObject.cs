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

    private SingleAssetLoader _loader = new SingleAssetLoader();

    private void Awake()
    {
        if (_isInit == true)
            InitObject();
    }

    public async void Spawn()
    {
        var handle = _loader.Load(_assetReference, _positionRoot);

        _cashedObject = await handle;
    }

    public async void SpawnWithEvent()
    {
        EnableEvent.CallEnabled(true);

        var handle = _loader.Load(_assetReference, _positionRoot);

        _cashedObject = await handle;
    }

    public void Despawn()
    {
        _loader.Unload();
    }

    public void DespawnSingle(GameObject gameobject)
    {
        _loader.Unload();
    }

    public void DespawnSingleWithEvent(GameObject gameobject)
    {
        EnableEvent.CallEnabled(false);

        _loader.Unload();
    }

    public async void InitObject()
    {
        var handle = _loader.Load(_assetReference, _positionRoot);

        _cashedObject = await handle;

        Despawn();
    }
}