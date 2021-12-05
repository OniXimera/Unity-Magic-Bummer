using UnityEngine;

public class FairWallEffect : MonoBehaviour
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
        {
            collision.GetComponent<Enemy>().TakeDamage(_damage);
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
