using UnityEngine;
using UnityEngine.Events;

public class TrigerSpawner : MonoBehaviour
{
    //fix 05.12.2021
    [Header("Connection: Spawner.SpawnEnemy")]
    [SerializeField] private UnityEvent<Wave[], Transform[]> _spawn;
    [Header("Parametor")]
    [SerializeField] private Wave[] _waves;
    [SerializeField] private Transform[] _spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            _spawn?.Invoke(_waves, _spawnPoint);
        }
    }
}
