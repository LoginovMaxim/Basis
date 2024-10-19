using Leopotam.EcsLite;

namespace Match.Ecs
{
    public sealed class MatchEcsWorldProvider : IMatchEcsWorldProvider
    {
        public EcsWorld World { get; } = new ();
    }
}