using System.Collections;
using UnityEngine;

public class PoolableObjectExample : PoolableObjectBase
{
    Coroutine _DeactivateCoroutine;

    public override void OnObjectCreated()
    {
        base.OnObjectCreated();
    }

    public override void OnGetFromPool()
    {
        base.OnGetFromPool();

        StopDeactivateCoroutine();

        _DeactivateCoroutine = StartCoroutine(DeactivateCoroutine(2f));
    }

    public override void OnReleaseToPool()
    {
        StopDeactivateCoroutine();

        base.OnReleaseToPool();
    }

    public override void OnDestroyPooledObject() 
    {
        StopDeactivateCoroutine();

        base.OnDestroyPooledObject();
    }

    private void StopDeactivateCoroutine()
    {
        if (_DeactivateCoroutine != null)
        {
            StopCoroutine(_DeactivateCoroutine);
            _DeactivateCoroutine = null;
        }
    }

    IEnumerator DeactivateCoroutine(float delay) 
    { 
        yield return new WaitForSeconds(delay);

        ObjectPool.Release(this);

        _DeactivateCoroutine = null;
    }
}
