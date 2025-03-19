using UnityEngine;

public class UnloadObject : MonoBehaviour
{
    private SingleAssetLoader _loader;

    public void SetLoader(SingleAssetLoader loader) => _loader = loader;

    public void Unload()
    {
        EnableEvent.CallEnabled(false);

        _loader.Unload();
    }
}