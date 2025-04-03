using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PoolAssetLoader
{
    private Queue<GameObject> _cashedObjects = new Queue<GameObject>();

    public async void Load(AssetReference assetReference, Transform positionRoot)
    {
        var handle = Addressables.InstantiateAsync(assetReference, positionRoot);

        _cashedObjects.Enqueue(await handle.Task);
    }

    public async void LoadWithInject(AssetReference assetReference, Transform positionRoot)
    {
        var handle = Addressables.InstantiateAsync(assetReference, positionRoot);

        DiContainerSingleton.Instance.Container.InjectGameObject(await handle.Task);

        _cashedObjects.Enqueue(await handle.Task);
    }

    public void UnloadFirst()
    {
        if (_cashedObjects.Count == 0)
            return;

        _cashedObjects.First().SetActive(false);

        Addressables.ReleaseInstance(_cashedObjects.First());

        _cashedObjects.Dequeue();
    }

    public void UnloadAll()
    {
        if (_cashedObjects.Count == 0)
            return;

        //Debug.Log(_cashedObjects.Count);

        //foreach (GameObject item in _cashedObjects)
        //{
        //    Debug.Log(item.name);
        //}

        for(int i = 0; i <= _cashedObjects.Count; i++)
        {
            UnloadFirst();
            //_cashedObjects.First().SetActive(false);
            
            //Addressables.ReleaseInstance(_cashedObjects.First());

            //_cashedObjects.Dequeue();
        }

        _cashedObjects.Clear();
    }

    public async Task UnloadAllWithEffects()
    {
        Debug.Log(_cashedObjects.Count);

        if (_cashedObjects.Count == 0)
            return;

        int index = _cashedObjects.Count;

        for (int i = 0; i < index; i++)
        {
            Debug.Log(_cashedObjects.Count);

            _cashedObjects.Peek().GetComponent<MoveY>().Move();

            await Task.Delay(_cashedObjects.Peek().GetComponent<MoveY>().durationTask);

            Addressables.ReleaseInstance(_cashedObjects.Peek());

            _cashedObjects.Dequeue();
        }

        await Task.Delay(1000);

        _cashedObjects.Clear();
    }
}