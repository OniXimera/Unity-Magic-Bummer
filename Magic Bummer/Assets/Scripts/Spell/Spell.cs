using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _damage;
    [SerializeField] private int _mp;

    public Player _player;
    public int Mp => this._mp;
    public Sprite Icon => this._icon;
    public int DamageCalculation()
    {
        return (int)(this._player.DamageCalculation() * this._damage);
    }

}
