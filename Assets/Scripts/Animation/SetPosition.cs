using UnityEngine;

public class SetPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 _newPosition;

    public void Set()
    {
        transform.SetLocalPositionAndRotation(_newPosition, transform.rotation);
    }
}