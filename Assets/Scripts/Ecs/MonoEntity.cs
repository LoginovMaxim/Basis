using Leopotam.EcsLite;

namespace Ecs
{
    public sealed class MonoEntity : MonoLinkBase
    {
        public EcsPackedEntityWithWorld Entity { get; private set; }
        
        private MonoLinkBase[] _monoLinks;

        public MonoLink<T> Get<T>() where T : struct
        {
            foreach (MonoLinkBase link in _monoLinks)
            {
                if (link is MonoLink<T> monoLink)
                {
                    return monoLink;
                }
            }

            return null;
        }

        public override void Make(ref EcsPackedEntityWithWorld entity)
        {
            Entity = entity;

            _monoLinks = GetComponents<MonoLinkBase>();
            foreach (MonoLinkBase monoLink in _monoLinks)
            {
                if (monoLink is MonoEntity)
                {
                    continue;
                }
                monoLink.Make(ref entity);
            }
        }
    }
}
