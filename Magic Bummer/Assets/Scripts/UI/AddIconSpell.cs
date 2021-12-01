using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddIconSpell : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private Image[] _action;
    [SerializeField] private Player _player;
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            this._action[i].sprite = this._player.Weapons[this._player.WeaponsId].Skilllists[i].SpellPrifab.GetComponent<Spell>().Icon;
        }
    }
}
