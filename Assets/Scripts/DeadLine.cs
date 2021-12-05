using UnityEngine;

public class DeadLine : MonoBehaviour
{
    //fix 05.12.2021
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Player>().GameOver();
    }
}
