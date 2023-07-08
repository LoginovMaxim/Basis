namespace Basis.Ecs
{
    public interface IComponentObserver<TComponent> where TComponent : struct
    {
        void OnComponentAdded(int entity, TComponent component);
        void OnComponentChanged(int entity, TComponent oldComponent, TComponent component);
        void OnComponentRemoved(int entity, TComponent component);
    }
}