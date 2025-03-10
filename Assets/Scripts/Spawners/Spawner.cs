using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Spawner
{
    private SpawnerConfig _config;

    private AssetReference[] _currentDifficulty;

    private Score _score;

    private Transform _transform;

    private WaitForSeconds _waitSpawn;

    private WaitForSeconds _waitDestroy;

    private Coroutine _currentCoroutine;

    private Coroutine _pastCoroutine;

    private PoolAssetLoader _loader = new PoolAssetLoader();

    public Spawner(SpawnerConfig config, Transform transform, Score score)
    {
        _config = config;

        _transform = transform;

        _transform.SetPositionAndRotation(_config.Offset, Quaternion.identity);

        _score = score;

        _waitSpawn = new WaitForSeconds(_config.TimeSpawn);

        _waitDestroy = new WaitForSeconds(_config.TimeDestroyObject);
    }

    public void Start()
    {
        _pastCoroutine = _currentCoroutine;

        _currentCoroutine = Coroutines.Start(Spawn());
    }

    private IEnumerator Spawn()
    {
        for(int i = 0; i < _config.Difficulty.Difficulty.Length; i++)
        {
            if(_score.CurrentScore >= _config.Difficulty.Difficulty[i].SpawnScore)
            {
                _currentDifficulty = _config.Difficulty.Difficulty[i].Prefabs;
            }
        }

        int randomPrefab = UnityEngine.Random.Range(0, _currentDifficulty.Length);

        yield return _waitSpawn;

        _loader.LoadWithInject(_currentDifficulty[randomPrefab], _transform);

        Start();

        yield return _waitDestroy;
        //Debug.Log("destroy");//hz vrode zarabotal Destroy
        _loader.UnloadFirst();
    }

    public void Stop()
    {
        Coroutines.Stop(_currentCoroutine);

        Coroutines.Stop(_pastCoroutine);
    }

    public void UnloadAll()
    {
        _loader.UnloadAll();
    }
}