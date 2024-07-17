using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class MixerInstaller : MonoInstaller
{
    [SerializeField]
    private AudioMixer _audioMixer;

    public override void InstallBindings()
    {
        Container.Bind<AudioMixer>().FromInstance(_audioMixer);
    }
}