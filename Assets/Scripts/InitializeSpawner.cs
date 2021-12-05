using UnityEngine;
using UnityEngine.Events;

public class InitializeSpawner : MonoBehaviour
{
    //fix 05.12.2021
    [Header("Connection: Spawner.Initialize")]
    [SerializeField] private UnityEvent<Monster[]> Spawn;
    [Header("Parametor")]
    [SerializeField] private Monster[] _monsters;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Spawn?.Invoke(_monsters);
            gameObject.SetActive(false);
        }
    }
}
