using Basis.Views;

namespace Basis.Pool
{
    public class PoolObject : BaseView, IPoolObject
    {
        public string ResourceId { get; set; }
        
        public bool IsActive => gameObject.activeSelf;
        
        public void Reinitialize()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}