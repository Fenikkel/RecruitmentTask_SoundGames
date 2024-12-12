using System.Collections;
using UnityEngine;

public class Flower : PoolableObject
{
    public override void OnGetFromPool()
    {
        base.OnGetFromPool();
    }

    public override void OnReleaseToPool()
    {
        base.OnReleaseToPool();
        transform.position = new Vector3(0, 15, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObjectPool.Release(this);
    }
}
