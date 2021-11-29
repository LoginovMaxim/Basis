using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private MonoUpdater MonoUpdaterPrefab;
    
    public override void InstallBindings()
    {
        Container.Bind<MonoUpdater>().FromComponentInNewPrefab(MonoUpdaterPrefab).AsSingle().NonLazy();
    }
}