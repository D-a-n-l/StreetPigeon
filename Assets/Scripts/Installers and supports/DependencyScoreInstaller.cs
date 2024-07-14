using UnityEngine;
using Zenject;

public class DependencyScoreInstaller : MonoInstaller
{
    [SerializeField]
    private Score _score;

    [SerializeField]
    private UpdateVelocityGame _updateVelocityGame;

    [SerializeField]
    private AppearingText _appearingText;

    public override void InstallBindings()
    {
        Container.Bind<Score>().FromInstance(_score);

        Container.Bind<UpdateVelocityGame>().FromInstance(_updateVelocityGame);
        
        Container.Bind<AppearingText>().FromInstance(_appearingText);
    }
}