using UnityEngine;

[CreateAssetMenu(fileName = "Preset Animation", menuName = "Animation/Preset Animation")]
public class PresetAnimation : ScriptableObject
{
    [field: SerializeField]
    public Sprite[] Frames;

    [field: Min(1)]
    [field: SerializeField]
    public float FrameRate = 12;
}