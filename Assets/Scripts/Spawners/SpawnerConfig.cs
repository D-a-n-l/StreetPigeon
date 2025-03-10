using UnityEngine;

[CreateAssetMenu(fileName = "Spawner Config", menuName = "Configs/Spawner Config")]
public class SpawnerConfig : ScriptableObject
{
    [field: SerializeField]
    public DifficultyConfig Difficulty { get; private set; }

    [field: SerializeField]
    public float TimeSpawn { get; private set; } = 5.5f;

    [field: SerializeField]
    public float TimeDestroyObject { get; private set; } = 11f;

    [field: SerializeField]
    public Vector2 Offset { get; private set; }
}