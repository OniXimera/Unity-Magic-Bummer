using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Witchcraft : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private Transform _spellPool;

    private Weapon.WeaponSkillist[] _weaponSkillist;
    private Dictionary<GameObject, GameObject[]> _listPrifab = new Dictionary<GameObject, GameObject[]>();
    private GameObject _result;

    private void Start()
    {
        this._weaponSkillist = GetComponent<Player>().Weapons[GetComponent<Player>().WeaponsId].Skilllists;
        StartCoroutine(InitializationSkillCorutine());
    }

    IEnumerator InitializationSkillCorutine()
    {       
        GameObject[] temp;
        foreach (Weapon.WeaponSkillist skilllist in this._weaponSkillist)
        {
            temp = new GameObject[skilllist.PoolLimit];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = Instantiate(skilllist.SpellPrifab, transform.position, Quaternion.identity, this._spellPool);
                temp[i].GetComponent<Spell>()._player = GetComponent<Player>();
                yield return new WaitForEndOfFrame();
            }
            this._listPrifab.Add(skilllist.SpellPrifab, temp);
        }
    }

    public void UseSpell(int id_spell)
    {
        this._result = this._listPrifab[this._weaponSkillist[id_spell].SpellPrifab].FirstOrDefault(p => p.activeSelf == false);
        if(this._result != null && GetComponent<Player>().ManaCost(this._weaponSkillist[id_spell].SpellPrifab.GetComponent<Spell>().Mp))
            this._result.gameObject.SetActive(true);
    }
}


