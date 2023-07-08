using Basis.Views;

namespace Basis.Pool
{
    public interface IViewPool
    {
        IViewObject Spawn();
        void Despawn(IViewObject viewObject);
    }
}