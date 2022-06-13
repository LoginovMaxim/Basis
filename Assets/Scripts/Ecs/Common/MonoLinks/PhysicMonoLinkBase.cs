using Leopotam.Ecs;

namespace Ecs.Common.MonoLinks
{
    public abstract class PhysicMonoLinkBase : MonoLinkBase
    {
		protected EcsEntity Entity;

		public override void Make(ref EcsEntity entity)
		{
			Entity = entity;
		}
	}
}
