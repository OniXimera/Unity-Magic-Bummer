using UnityEngine;

public class MeteorFly : MonoBehaviour
{
    //fix 05.12.2021
    public GameObject Effect;
    private bool _delete;

    private void OnEnable()
    {
        _delete = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_delete && collision.tag == "Ground")
        {
            Explosion(transform.position);
            gameObject.SetActive(false);
            _delete = true;
        }
    }

    public void Explosion(Vector3 position)
    {
        Effect.transform.position = position + new Vector3(0, -0.5f, 0);
        Effect.SetActive(true);
    }
}
