using UnityEngine;

public class FireBall : Spell
{
    //fix 05.12.2021
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private GameObject[] _effect;

    private float _lifeTimeTemp;
    private void OnEnable()
    {
        _lifeTimeTemp = _lifeTime;

        if (_player.GetComponent<SpriteRenderer>().flipX)
        {
            _effect[0].transform.position = _player.transform.position + new Vector3(1f, 0.6f);
            _effect[0].transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            _effect[0].transform.position = _player.transform.position + new Vector3(-1f, 0.6f);
            _effect[0].transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        _effect[0].SetActive(true);
    }

    private void Update()
    {
        if (_lifeTimeTemp > 0)
        {
            _effect[0].transform.Translate(Vector2.left * _speed * Time.deltaTime);
            _lifeTimeTemp -= Time.deltaTime;
        }
        else
        { 
            gameObject.SetActive(false); 
        }
    }

    public void Explosion(Vector3 position)
    {
        _effect[1].transform.position = position;
        _effect[1].SetActive(true);
    }
}
