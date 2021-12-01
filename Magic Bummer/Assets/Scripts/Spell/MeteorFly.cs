using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFly : MonoBehaviour
{
    //fix 30.11.2021
    public GameObject Effect;
    private bool _delete;

    private void OnEnable()
    {
        this._delete = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this._delete && collision.tag == "Ground")
        {
            Explosion(transform.position);
            gameObject.SetActive(false);
            this._delete = true;
        }

    }

    public void Explosion(Vector3 position)
    {
        this.Effect.transform.position = position + new Vector3(0, -0.5f, 0);
        this.Effect.SetActive(true);
    }
}
