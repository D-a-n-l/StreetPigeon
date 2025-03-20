using Zenject;
using UnityEngine;

public class RefrashableTimeScaleAndScoreInstaller : MonoInstaller
{
    [Min(1)]
    [SerializeField]
    private int _increaseEvery;

    [Range(0f, 0.5f)]
    [SerializeField]
    private float _howAddTimeScale;

    [Min(0.5f)]
    [SerializeField]
    private float _baseTimeScale;

    [Min(5f)]
    [SerializeField]
    private float _maxTimeScale;

    public override void InstallBindings()
    {
        Score score = new Score();

        Container.Bind<Score>().FromInstance(score).AsSingle();

        RefrashableTimeScaleFromScore refrashableTimeScale = new RefrashableTimeScaleFromScore(_increaseEvery, _howAddTimeScale, _baseTimeScale, _maxTimeScale, score);

        Container.Bind<RefrashableTimeScaleFromScore>().FromInstance(refrashableTimeScale);
    }
}