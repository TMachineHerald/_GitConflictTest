using UnityEngine;

/// <summary>
/// Persistent singleton.
/// </summary>
public class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    private static readonly object _lock = new object();

    public static bool IsNull
    {
        get
        {
            return _instance == null;
        }
    }

    /// <summary>
    /// Singleton design pattern
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {

        get
        {

#if UNITY_EDITOR  //FyAdd: under the unityEditor, check if  the instance is multiple
            var _Array = FindObjectsOfType<T>();
            if (_Array.Length >= 2)
            {
                Debug.LogError($"Warning ! multiple instance in scene! ");
                foreach (var item in _Array)
                {
                    Debug.LogWarning($"Instance {typeof(T)}: {item.name}");
                }
            }
#endif
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        Debug.LogError("空引用, 请检查你的场景中是否存在该单例;或者在你调用的时候该单例尚且没有Awake()");
                        Debug.LogError(typeof(T).ToString() + "is null!!!");
                        //Fy delete : cancel automatic create instance
                        // GameObject obj = new GameObject("TempObj");
                        // _instance = obj.AddComponent<T>();

                        //dontdestroyonload(_instance);
                    }

                }
            }
            return _instance;
        }
    }
}
