using System;
using UnityEngine;
using UnityEngine.Pool;

public interface IPoolableObject
{
    Transform transform { get; } // Force to get only monobehaviours
    GameObject gameObject { get; } // Force to get only monobehaviours

    public IObjectPool<IPoolableObject> ObjectPool { get; set; }

    public void OnObjectCreated();
    public void OnGetFromPool();
    public void OnReleaseToPool();
    public void OnDestroyPooledObject();
}
