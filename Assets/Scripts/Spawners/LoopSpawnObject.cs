using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class LoopSpawnObject : MonoBehaviour
{
    [SerializeField]
    private SpawnerPreset _spawnerPreset;

    [Space]
    [SerializeField] 
    private float _timeSpawn = 5f;

    [SerializeField] 
    private float _timeDestroyObject = 5f;

    private AssetReference[] _currentDifficultyPrefabs;

    private WaitForSeconds _waitSpawn;

    private WaitForSeconds _waitDestroy;

    private Score _score;

    [Inject]
    public void Construct(Score score)
    {
        _score = score;
    }

    public void Init()
    {
        _waitSpawn = new WaitForSeconds(_timeSpawn);
        
        _waitDestroy = new WaitForSeconds(_timeDestroyObject);
    }

    public IEnumerator Load()
    {
        for(int i = 0; i < _spawnerPreset.difficulty.Length; i++)
        {
            if(_score.CurrentScore >= _spawnerPreset.difficulty[i].spawnScore)
            {
                _currentDifficultyPrefabs = _spawnerPreset.difficulty[i].prefabs;
            }
        }

        int randomPrefab = Random.Range(0, _currentDifficultyPrefabs.Length);

        yield return _waitSpawn;

        LocalAssetLoader.LoadInternalPool(_currentDifficultyPrefabs[randomPrefab], transform);
        
        StartCoroutine(Load());

        yield return _waitDestroy;

        LocalAssetLoader.UnloadInternalPool();
    }
}