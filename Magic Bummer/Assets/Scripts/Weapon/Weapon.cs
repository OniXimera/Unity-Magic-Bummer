using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private float _damage;
    [SerializeField] private WeaponSkillist[] _skilllist;

    public WeaponSkillist[] Skilllists => this._skilllist;
    public float Damage => this._damage;

    [System.Serializable]
    public class WeaponSkillist
    {
        public GameObject SpellPrifab;
        public int PoolLimit;
    }
}
