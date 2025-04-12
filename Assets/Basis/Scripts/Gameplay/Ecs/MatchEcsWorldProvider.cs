using Leopotam.EcsLite;

namespace Basis.Gameplay.Ecs
{
    public sealed class MatchEcsWorldProvider : IMatchEcsWorldProvider
    {
        public EcsWorld World { get; } = new ();
    }
}