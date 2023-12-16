using BasisCore.Runtime.Reactive;
using BasisCore.Runtime.UI.Screens;

namespace Project.Match.UI.Gameplay
{
    public sealed class GameplayScreenModel : BaseScreenModel
    {
        public ReactiveCommand QuitCommand { get; } = new();
    }
}