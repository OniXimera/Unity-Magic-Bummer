using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairWallEffect : MonoBehaviour
{
    //fix 30.11.2021
    private int _damage;
    private void OnEnable()
    {
        this._damage = transform.parent.gameObject.GetComponent<Spell>().DamageCalculation();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(this._damage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }

    private void DisableFairWall()//Animation Event
    {
        transform.parent.gameObject.SetActive(false);
    }
}
