using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private string _keyParameter;

    public void Set(bool value) => _animator.SetBool(_keyParameter, value);
}