using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InitializeSpawner : MonoBehaviour
{
    //fix 30.11.2021
    [Header("Connection: Spawner.Initialize")]
    [SerializeField] private UnityEvent<Monster[]> Spawn;
    [Header("Parametor")]
    [SerializeField] private Monster[] _monsters;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            this.Spawn?.Invoke(this._monsters);
            gameObject.SetActive(false);
        }
    }
}
