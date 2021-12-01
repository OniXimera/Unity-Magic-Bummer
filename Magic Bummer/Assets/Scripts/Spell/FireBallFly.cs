using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallFly : MonoBehaviour
{
    //fix 30.11.2021
    private bool _delete;

    private void OnEnable()
    {
        this._delete = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!this._delete && collision.tag == "Enemy")
        {
            transform.parent.gameObject.GetComponent<FireBall>().Explosion(transform.position);
            gameObject.SetActive(false);
            this._delete = true;
        }

    }
}
