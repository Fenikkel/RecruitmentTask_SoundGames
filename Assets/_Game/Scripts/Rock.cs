using System.Collections;
using UnityEngine;

public class Rock : PoolableObject
{
    [Range(0.7f, 1f)]
    [SerializeField] float _SizeMinVariation = 0.7f;

    [Range(1f, 1.3f)]
    [SerializeField] float _SizeMaxVariation = 1.3f;

    Vector3 _OriginalSize;

    public override void OnObjectCreated()
    {
        base.OnObjectCreated();
        _OriginalSize = transform.localScale;
    }

    public override void OnGetFromPool()
    {
        base.OnGetFromPool();
        transform.localScale = _OriginalSize * Random.Range(_SizeMinVariation, _SizeMaxVariation);
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
