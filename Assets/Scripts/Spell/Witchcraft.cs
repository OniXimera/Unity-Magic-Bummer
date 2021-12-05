using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Witchcraft : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private Transform _spellPool;

    private WeaponSkillist[] _weaponSkillist;
    private Dictionary<GameObject, GameObject[]> _listPrifab = new Dictionary<GameObject, GameObject[]>();
    private GameObject _result;

    private void Start()
    {
        _weaponSkillist = GetComponent<Player>().Weapons[GetComponent<Player>().WeaponsId].Skilllists;
        StartCoroutine(InitializationSkillCorutine());
    }

    IEnumerator InitializationSkillCorutine()
    {       
        GameObject[] temp;

        foreach (WeaponSkillist skilllist in _weaponSkillist)
        {
            temp = new GameObject[skilllist.PoolLimit];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = Instantiate(skilllist.SpellPrifab, transform.position, Quaternion.identity, _spellPool);
                temp[i].GetComponent<Spell>()._player = GetComponent<Player>();
                yield return new WaitForEndOfFrame();
            }

            _listPrifab.Add(skilllist.SpellPrifab, temp);
        }
    }

    public void UseSpell(int id_spell)
    {
        _result = _listPrifab[_weaponSkillist[id_spell].SpellPrifab].FirstOrDefault(p => p.activeSelf == false);
        
        if(_result != null && GetComponent<Player>().ManaCost(_weaponSkillist[id_spell].SpellPrifab.GetComponent<Spell>().Mp))
            _result.gameObject.SetActive(true);
    }
}


