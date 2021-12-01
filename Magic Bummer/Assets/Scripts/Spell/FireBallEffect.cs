using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEffect : MonoBehaviour
{
    //fix 30.11.2021
    private int _damage;
    private void OnEnable()
    {
        this._damage = transform.parent.gameObject.GetComponent<Spell>().DamageCalculation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
            collision.GetComponent<Enemy>().TakeDamage(this._damage);
    }

    private void DisableFireBall()//Animation Event
    {
        gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
