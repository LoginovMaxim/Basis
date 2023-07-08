using UnityEngine;

namespace Basis.Monos
{
    public class GameObjectFinder : MonoBehaviour, IGameObjectFinder
    {
        public T GetGameObject<T>() where T : MonoBehaviour
        {
            return FindObjectOfType<T>(true);
        }
        
        public T[] GetGameObjects<T>() where T : MonoBehaviour
        {
            return FindObjectsOfType<T>(true);
        }
    }
}