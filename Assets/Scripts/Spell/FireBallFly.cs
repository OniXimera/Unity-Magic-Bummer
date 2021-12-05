using UnityEngine;

public class FireBallFly : MonoBehaviour
{
    //fix 05.12.2021
    private bool _delete;

    private void OnEnable()
    {
        _delete = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_delete && collision.tag == "Enemy")
        {
            transform.parent.gameObject.GetComponent<FireBall>().Explosion(transform.position);
            gameObject.SetActive(false);
            _delete = true;
        }

    }
}
