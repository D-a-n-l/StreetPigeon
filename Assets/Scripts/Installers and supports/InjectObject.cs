using UnityEngine;

public class InjectObject : MonoBehaviour
{
    private void Start() => DiContainerSingleton.Instance.Container.InjectGameObject(gameObject);
}