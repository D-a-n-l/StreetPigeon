using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private bool isDestroyItem = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerFeature player))
        {
            Destroy(other.gameObject);
        }    

        if (isDestroyItem)
        {
            Destroy(other.gameObject);
        }
    }
}
