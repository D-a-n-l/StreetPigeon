using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "PresetSpawn", menuName = "Spawner/PresetSpawn")]
public class SpawnerPreset : ScriptableObject
{
    public PresetDifficulty[] difficulty;
}

[System.Serializable]
public struct PresetDifficulty
{
    public int spawnScore;

    public AssetReference[] prefabs;
}