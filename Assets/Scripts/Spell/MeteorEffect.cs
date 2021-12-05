using UnityEngine;

public class MeteorEffect : MonoBehaviour
{
    //fix 05.12.2021
    private int _damage;

    private void OnEnable()
    {
        _damage = transform.parent.gameObject.GetComponent<Spell>().DamageCalculation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            collision.GetComponent<Enemy>().TakeDamage(_damage);
    }

    private void DisableMeteorEffect()//Animation Event
    {
        gameObject.SetActive(false);
        transform.parent.GetComponent<Meteor>().Fanal();
    }
}
