using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObjectSpawner2D : MonoBehaviour
{
    [SerializeField] ObjectPool _ObjectPool;

    BoxCollider2D _BoxCollider2D;

    private void Start()
    {
        _BoxCollider2D = GetComponent<BoxCollider2D>();
    }

#if UNITY_EDITOR && true
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            RandomSpawn();
        }
    }
#endif

    public void RandomSpawn() 
    {
        IPoolableObject poolableObject = _ObjectPool.GetObject();

        Vector2 randomPos = GetRandomPointInsideCollider(_BoxCollider2D);

        poolableObject.transform.position = new Vector3(randomPos.x, randomPos.y, transform.position.z);

    }

    private Vector2 GetRandomPointInsideCollider(BoxCollider2D boxCollider2D)
    {
        Vector2 colliderWorldPivot = (Vector2)boxCollider2D.transform.position + (boxCollider2D.offset * boxCollider2D.transform.lossyScale); // * localScale? 

        float colliderWidth = boxCollider2D.size.x * boxCollider2D.transform.lossyScale.x;
        float colliderHeight = boxCollider2D.size.y * boxCollider2D.transform.lossyScale.y;

        float randomPosX = Random.Range(colliderWorldPivot.x - colliderWidth / 2, colliderWorldPivot.x + colliderWidth / 2);
        float randomPosY = Random.Range(colliderWorldPivot.y - colliderHeight / 2, colliderWorldPivot.y + colliderHeight / 2);

        return new Vector2 (randomPosX, randomPosY);
    }
}
