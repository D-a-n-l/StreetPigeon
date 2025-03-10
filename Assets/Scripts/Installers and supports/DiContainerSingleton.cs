using UnityEngine;
using Zenject;

public class DiContainerSingleton : MonoBehaviour//этот скрипт и InjectObject нужны для спавна Enemy, чтобы все заинжектить т.к. они Addresables
{
    public static DiContainerSingleton Instance { get; private set; }

    [Inject]
    public DiContainer Container { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);

            return;
        }

        DontDestroyOnLoad(this);
    }
}