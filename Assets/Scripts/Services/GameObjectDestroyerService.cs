using UnityEngine;

namespace Services
{
    public class GameObjectDestroyerService : MonoBehaviour
    {
        public void DestroyGameObject(GameObject gameObjectToDestroy)
        {
            Destroy(gameObjectToDestroy);
        }
    }
}