using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageAlphaHit : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    private float _alpha;

    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = _alpha;
    }
}