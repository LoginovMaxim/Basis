using Leopotam.EcsLite;

namespace Ecs.Common.MonoLinks
{
    public abstract class PhysicMonoLinkBase : MonoLinkBase
    {
		protected EcsPackedEntityWithWorld Entity;

		public override void Make(ref EcsPackedEntityWithWorld entity)
		{
			Entity = entity;
		}
	}
}
