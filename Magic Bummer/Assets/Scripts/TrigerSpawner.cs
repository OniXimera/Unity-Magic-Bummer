using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigerSpawner : MonoBehaviour
{
    //fix 30.11.2021
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
            this._spawn?.Invoke(this._waves, this._spawnPoint);
        }
    }
}
