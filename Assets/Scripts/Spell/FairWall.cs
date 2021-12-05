using UnityEngine;

public class FairWall : Spell
{
    //fix 05.12.2021
    [SerializeField] private float _speed;
    [SerializeField] private GameObject[] _effect;

    private void OnEnable()
    {
        _effect[0].transform.position = _player.transform.position + new Vector3(0.5f, 0, 0);
        _effect[1].transform.position = _player.transform.position + new Vector3(-0.5f, 0, 0);
    }

    private void Update()
    {
        _effect[0].transform.Translate(Vector2.right * _speed * Time.deltaTime);
        _effect[1].transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
