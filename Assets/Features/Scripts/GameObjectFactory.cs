using UnityEngine;

namespace TestTask
{
    public abstract class GameObjectFactory : ScriptableObject
    {
        public T CreateGameObjectInstance<T>(T prefab, Transform parrent = null,
            Vector3 pos=new Vector3(), Vector3 rot=new Vector3(), float scale = 1) where T : MonoBehaviour
        {
            var instance = Instantiate(prefab);
            instance.transform.SetParent(parrent);
            instance.transform.localPosition = pos;
            instance.transform.eulerAngles = rot;
            instance.transform.localScale = new Vector3(scale, scale, scale);
            return instance;
        }
    }
}