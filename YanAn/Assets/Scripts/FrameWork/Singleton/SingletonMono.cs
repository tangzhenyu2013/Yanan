using UnityEngine;
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (FindObjectsOfType<T>().Length > 1)
                {
                    Debug.LogError("不能存在多个单例");
                    return _instance;
                }

                if (_instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}