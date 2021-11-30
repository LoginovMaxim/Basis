using UnityEngine;

namespace Monos
{
    public class ViewModelFinder : MonoBehaviour
    {
        public T GetViewModel<T>() where T : MonoBehaviour
        {
            return FindObjectOfType<T>(true);
        }
        
        public T[] GetViewModels<T>() where T : MonoBehaviour
        {
            return FindObjectsOfType<T>(true);
        }
    }
}