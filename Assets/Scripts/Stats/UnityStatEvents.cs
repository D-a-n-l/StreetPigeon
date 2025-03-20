using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UnityStatEvents : SelectableStat
{
    [SerializeField]
    private UnityEvent OnDecreased;

    [SerializeField]
    private UnityEvent OnIncreased;

    [SerializeField]
    private UnityEvent OnZeroing;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);

        _stat.OnDecreased += OnDecreased.Invoke;
        _stat.OnIncreased += OnIncreased.Invoke;
        _stat.OnZeroing += OnZeroing.Invoke;
    }

    private void OnDisable()
    {
        _stat.OnDecreased -= OnDecreased.Invoke;
        _stat.OnIncreased -= OnIncreased.Invoke;
        _stat.OnZeroing -= OnZeroing.Invoke;
    }
}