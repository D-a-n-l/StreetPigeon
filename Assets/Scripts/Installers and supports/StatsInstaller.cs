using Zenject;

public class StatsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindHealth();

        BindEnergy();
    }

    private void BindHealth()
    {
        Health health = new Health(100);

        Container.Bind<Health>().FromInstance(health).AsSingle();
    }

    private void BindEnergy()
    {
        Energy energy = new Energy(100);

        Container.Bind<Energy>().FromInstance(energy).AsSingle();
    }
}