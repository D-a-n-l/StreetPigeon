using UnityEngine;
using Zenject;

public class SceneContextSingleton : MonoBehaviour//этот скрипт и InjectObject нужны для спавна Enemy, чтобы все заинжектить т.к. они Addresables
{
    public static SceneContext Instance;

    private void Awake() => Instance = GetComponent<SceneContext>();
}