using Basis.App.Views;

namespace Basis.App.Pool
{
    public interface IViewPool
    {
        IViewObject Spawn();
        void Despawn(IViewObject viewObject);
    }
}