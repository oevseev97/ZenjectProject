using UnityEngine;
using Zenject;

public class GloabalInstaller : MonoInstaller
{
    public Settings settings;
    public SaveLoad saveLoad;
    public SceneContext sceneContext;
    public MusicPlayer musicPlayer;
    public override void InstallBindings()
    {
       Container.Bind<Settings>().FromInstance(settings).AsSingle().NonLazy();
       Container.Bind<SaveLoad>().FromInstance(saveLoad).AsSingle().NonLazy();
       Container.Bind<SceneContext>().FromInstance(sceneContext).AsSingle().NonLazy();
       Container.Bind<MusicPlayer>().FromInstance(musicPlayer).AsSingle().NonLazy();

       // Services services = new Services(_settings, _saveLoad, _sceneContext);
      // Container.Bind<Services>().AsSingle();
    }
}