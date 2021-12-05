using UnityEngine;

public class FireRay : Spell
{
    //fix 05.12.2021
    private void OnEnable()
    {
        RaycastHit2D[] temp;
        _player.GetComponent<Move>().enabled = false;
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (_player.GetComponent<SpriteRenderer>().flipX)
        {
            transform.position = _player.transform.position + new Vector3(1f, 0.6f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            temp = Physics2D.RaycastAll(transform.position, Vector3.right, 15);
        }
        else
        {
            transform.position = _player.transform.position + new Vector3(-1f, 0.6f);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            temp = Physics2D.RaycastAll(transform.position, Vector3.left, 15);
        }


        foreach (RaycastHit2D item in temp)
        {
            if(item.collider.tag == "Enemy")
            {
                item.collider.GetComponent<Enemy>().TakeDamage(DamageCalculation());
            }
        }
    }

    private void DisableFireRay()//Animation Event
    {
        _player.GetComponent<Move>().enabled = true;
        gameObject.SetActive(false);
    }
}
