using System.Threading.Tasks;

namespace Basis.Pool
{
    public interface IPoolService
    {
        Task<TPoolObject> Spawn<TPoolObject>(string resource) where TPoolObject : PoolObject;
        void Despawn(PoolObject poolObject);
    }
}