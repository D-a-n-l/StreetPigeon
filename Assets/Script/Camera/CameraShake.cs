using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ShakeCamera()
    {
        animator.SetTrigger("isShake");
    }
}
