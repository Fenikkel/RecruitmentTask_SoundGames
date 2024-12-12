using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _ObjectPrefab;

    [Header("Pool config")]
    [SerializeField] int _StartSize = 20;
    [SerializeField] int _MaxSize = 100;
    [SerializeField] bool _ColectionCheck = true; // Only works in editor: throw an exception if we try to return an existing item,already in the pool

    IObjectPool<IPoolableObject> _ObjectPool;

    private void Awake()
    {
        _ObjectPool = new ObjectPool<IPoolableObject>(CreateObject, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, _ColectionCheck, _StartSize, _MaxSize);
    }

#if UNITY_EDITOR && false
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            IPoolableObject spawnableObject = GetObject();
            Debug.Log($"Spawned {spawnableObject.gameObject.name}");
        }
    }
#endif

    public IPoolableObject GetObject() 
    {
        return _ObjectPool.Get();
    }

    public void ReleaseObject(IPoolableObject pooledObject) 
    { 
        _ObjectPool.Release(pooledObject);
    }

    #region ObjectPool functions
    private IPoolableObject CreateObject() 
    {
        GameObject goInstance = Instantiate(_ObjectPrefab.gameObject);

        IPoolableObject spawnableObject = goInstance.GetComponent<IPoolableObject>();
        if (spawnableObject == null) 
        {
            Debug.Log($"{_ObjectPrefab.name} must have the {typeof(IPoolableObject)} interface inplemented.");
            return null;
        }

        goInstance.name = $"{spawnableObject.GetType()}"; // $"{spawnableObject.GetType()} {_ObjectPool.CountAll}" -> Unity 6 or above

        spawnableObject.ObjectPool = _ObjectPool;
        spawnableObject.OnObjectCreated();

        return spawnableObject;
    }

    private void OnGetFromPool(IPoolableObject spawnableObject) 
    { 
        spawnableObject.OnGetFromPool();
    }

    private void OnReleaseToPool(IPoolableObject spawnableObject)
    {
        spawnableObject.OnReleaseToPool();
    }

    private void OnDestroyPooledObject(IPoolableObject spawnableObject)
    {
        Debug.LogWarning("OnDestroyPooledObject");
        spawnableObject.OnDestroyPooledObject();
    }
    #endregion
}
