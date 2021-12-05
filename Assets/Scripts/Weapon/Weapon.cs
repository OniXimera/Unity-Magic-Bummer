using UnityEngine;

public class Weapon : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private float _damage;
    [SerializeField] private WeaponSkillist[] _skilllist;

    public WeaponSkillist[] Skilllists => _skilllist;
    public float Damage => _damage;
}

[System.Serializable]
public class WeaponSkillist
{
    public GameObject SpellPrifab;
    public int PoolLimit;
}
