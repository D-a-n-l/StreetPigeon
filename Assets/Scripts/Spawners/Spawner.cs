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

    private bool _isNextStart = true;

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
        //_isNextStart = true;

        //Coroutines.Stop(_currentCoroutine);

        //_currentCoroutine = Coroutines.Start(Spawn());
        _pastCoroutine = _currentCoroutine;

        _currentCoroutine = Coroutines.Start(Spawn());
    }

    //private IEnumerator Spawn()
    //{
    //    for (int i = 0; i < _config.Difficulty.Difficulty.Length; i++)
    //    {
    //        if (_score.CurrentScore >= _config.Difficulty.Difficulty[i].Score)
    //        {
    //            _currentDifficulty = _config.Difficulty.Difficulty[i].Prefabs;
    //        }
    //    }

    //    int randomPrefab = UnityEngine.Random.Range(0, _currentDifficulty.Length);

    //    _loader.LoadWithInject(_currentDifficulty[randomPrefab], _transform);

    //    yield return _waitSpawn;

    //    if (_isNextStart == true)
    //        _currentCoroutine = Coroutines.Start(Spawn());

    //    yield return _waitDestroy;

    //    _loader.UnloadFirst();
    //}

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _config.Difficulty.Difficulty.Length; i++)
        {
            if (_score.CurrentScore >= _config.Difficulty.Difficulty[i].Score)
            {
                _currentDifficulty = _config.Difficulty.Difficulty[i].Prefabs;
            }
        }

        int randomPrefab = UnityEngine.Random.Range(0, _currentDifficulty.Length);

        yield return _waitSpawn;

        _loader.LoadWithInject(_currentDifficulty[randomPrefab], _transform);

        if (_isNextStart == true)
            Start();

        yield return _waitDestroy;

        _loader.UnloadFirst();
    }

    public void Stop()
    {
        //_isNextStart = false;
        Coroutines.Stop(_currentCoroutine);

        Coroutines.Stop(_pastCoroutine);
    }

    public void UnloadAll()
    {
        _loader.UnloadAll();
    }
}