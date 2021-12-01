using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    //fix 30.11.2021
    private void DisableBarrier()//Animation Event
    {
        transform.parent.gameObject.SetActive(false);
    }
}
