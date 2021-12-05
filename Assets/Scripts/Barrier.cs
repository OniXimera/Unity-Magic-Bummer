using UnityEngine;

public class Barrier : MonoBehaviour
{
    //fix 05.12.2021
    private void DisableBarrier()//Animation Event
    {
        transform.parent.gameObject.SetActive(false);
    }
}
