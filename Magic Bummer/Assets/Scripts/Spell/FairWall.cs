using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairWall : Spell
{
    //fix 30.11.2021
    [SerializeField] private float _speed;
    [SerializeField] private GameObject[] _effect;

    private void OnEnable()
    {
        this._effect[0].transform.position = _player.transform.position + new Vector3(0.5f, 0, 0);
        this._effect[1].transform.position = _player.transform.position + new Vector3(-0.5f, 0, 0);
    }

    private void Update()
    {
        this._effect[0].transform.Translate(Vector2.right * this._speed * Time.deltaTime);
        this._effect[1].transform.Translate(Vector2.left * this._speed * Time.deltaTime);
    }
}
