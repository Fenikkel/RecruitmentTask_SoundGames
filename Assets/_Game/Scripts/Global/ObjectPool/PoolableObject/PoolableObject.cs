using UnityEngine;
using UnityEngine.Pool;

public class PoolableObject : MonoBehaviour, IPoolableObject
{
    IObjectPool<IPoolableObject> _ObjectPool; // Reference to his object pool

    public IObjectPool<IPoolableObject> ObjectPool
    {
        get { return _ObjectPool; }
        set { _ObjectPool = value; }
    }

    public virtual void OnObjectCreated()
    {
    }

    public virtual void OnGetFromPool()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnReleaseToPool()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnDestroyPooledObject()
    {
        Destroy(gameObject);
    }
}
