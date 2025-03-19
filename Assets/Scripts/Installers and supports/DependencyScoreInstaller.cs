using Zenject;

public class DependencyScoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Score score = new Score();

        Container.Bind<Score>().FromInstance(score).AsSingle();

        UpdateVelocityGame updateVelocityGame = new UpdateVelocityGame(2, 0.1f, 1, 2.5f, score);

        Container.Bind<UpdateVelocityGame>().FromInstance(updateVelocityGame);
    }
}