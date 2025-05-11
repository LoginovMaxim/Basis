using BasisCore.UI.WindowManager;
using UnityEngine;
using Zenject;

namespace Basis.Core.Installers
{
    public sealed class CoreUIInstaller : MonoInstaller
    {
        [SerializeField] private UIRoot _uiRootPrefab;

        public override void InstallBindings()
        {
            var windowManagerSettings = new WindowManagerSettings
            {
                RootPrefab = _uiRootPrefab
            };

            Container.BindInstance(windowManagerSettings);
        }
    }
}