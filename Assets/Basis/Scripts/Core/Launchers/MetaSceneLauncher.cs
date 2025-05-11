using System.Threading;
using BasisCore.GameState;
using BasisCore.Launchers;
using Cysharp.Threading.Tasks;

namespace Basis.Core.Launchers
{
    public sealed class MetaSceneLauncher : ILauncher
    {
        private readonly IGameStateController _gameStateController;

        public MetaSceneLauncher(IGameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public async UniTask LaunchAsync(CancellationToken token)
        {
            await _gameStateController.SwitchStateAsync(GameStateType.Meta);
        }
    }
}