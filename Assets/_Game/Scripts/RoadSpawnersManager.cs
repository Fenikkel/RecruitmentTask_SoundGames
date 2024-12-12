using System.Collections;
using UnityEngine;

public class RoadSpawnersManager : MonoBehaviour
{
    [SerializeField] Rigidbody _CarRigidbody;
    [SerializeField] float _SpeedThershold = 2f; 

    [Header("Flowers")]
    [SerializeField] ObjectSpawner2D _FlowersSpawner;
    [SerializeField] float _FlowerMinTimeBetweenSpawn = 0.5f; 
    [SerializeField] float _FlowerMaxTimeBetweenSpawn = 2f;

    [Header("Rocks")]
    [SerializeField] ObjectSpawner2D _RocksSpawner;
    [SerializeField] float _RockMinTimeBetweenSpawn = 1f;
    [SerializeField] float _RockMaxTimeBetweenSpawn = 4f;


    Coroutine _FlowersCoroutine;
    Coroutine _RocksCoroutine;

    private void Start()
    {
        _FlowersCoroutine = StartCoroutine(SpawnFlowerCoroutine());
        _RocksCoroutine = StartCoroutine(SpawnRockCoroutine());
    }

    IEnumerator SpawnFlowerCoroutine() 
    {
        WaitForSeconds wait;

        while (true) 
        {
            wait = new WaitForSeconds(Random.Range(_FlowerMinTimeBetweenSpawn, _FlowerMaxTimeBetweenSpawn));

            yield return wait;

            if (_SpeedThershold < _CarRigidbody.velocity.x) // Don't spawn at lower speeds
            {
                //Debug.Log(_CarRigidbody.velocity.x);
                _FlowersSpawner.RandomSpawn();
            }
            
        }

        //_FlowersCoroutine = null;
    }

    IEnumerator SpawnRockCoroutine()
    {
        WaitForSeconds wait;

        while (true)
        {
            wait = new WaitForSeconds(Random.Range(_RockMinTimeBetweenSpawn, _RockMaxTimeBetweenSpawn));

            yield return wait;

            if (_SpeedThershold < _CarRigidbody.velocity.x) // Don't spawn at lower speeds
            {
                //Debug.Log(_CarRigidbody.velocity.x);
                _RocksSpawner.RandomSpawn();
            }

        }

        //_RocksCoroutine = null;
    }
}
