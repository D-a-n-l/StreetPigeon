using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.AddressableAssets;
 
[CreateAssetMenu(fileName = "New skins", menuName = "Skins/New skins")]
public class Skins : ScriptableObject
{
    [SerializedDictionary("Name", "Preset")]
    public SerializedDictionary<string, SkinPreset> List = new SerializedDictionary<string, SkinPreset>();
}

[System.Serializable]
public struct SkinPreset
{
    public string Name;

    public Vector3 Position;

    public Vector3 Scale;

    public PresetAnimation PresetAnimation;

    public AssetReference Prefab;
}