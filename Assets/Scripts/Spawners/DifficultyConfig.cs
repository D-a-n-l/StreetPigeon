using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "Difficulty", menuName = "Configs/Difficulty")]
public class DifficultyConfig : ScriptableObject
{
    [field: SerializeField]
    public DifficultyPreset[] Difficulty { get; private set; }
}

[System.Serializable]
public struct DifficultyPreset
{
    public int Score;

    public AssetReference[] Prefabs;
}