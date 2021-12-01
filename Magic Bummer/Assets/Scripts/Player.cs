using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //fix 30.11.2021
    [Header("Character characteristics")]
    [SerializeField] private int _healthMax;
    [SerializeField] private int _manaMax;
    [SerializeField] private int _power;
    [SerializeField] private int _bonusPowerMax;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [Header("Character UI")]
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private Slider _sliderMP;
    [SerializeField] private Slider _sliderPW;
    [SerializeField] private GameObject _gameOverScreen;
    [Header("Character Weapons")]
    [SerializeField] private Weapon[] _weapons;
    [SerializeField] private int _weaponsId;


    public Weapon[] Weapons => _weapons;
    public int WeaponsId => _weaponsId;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;

    private int _health;
    private int _mana;
    private int _bonusPower;


    private void Start()
    {        
        this._sliderHP.value = this._sliderHP.maxValue = this._health = this._healthMax;
        this._sliderMP.value = this._sliderMP.maxValue = this._mana = this._manaMax;
        this._sliderPW.value = this._bonusPower;
        this._sliderPW.maxValue = this._bonusPowerMax;

    }
    public void SetWeapons(int weaponId)
    {
        this._weaponsId = weaponId;
    }

    public bool ManaCost(int cost)
    {
        if (this._mana >= cost)
        {
            this._mana -= cost;
            if (this._mana >= this._manaMax)
                this._mana = this._manaMax;
            this._sliderMP.value = this._mana;
            return true;
        }
        return false;
    }

    public void ApplyDamage(int damage)
    {
        this._health -= damage;
        this._sliderHP.value = this._health;
        PowerFine(damage);
        if (this._health <= 0)
            GameOver();
    }

    public void GameOver()
    {
        this._gameOverScreen.SetActive(true);
    }

    public void PowerBonus(int bonus)
    {
        if (this._bonusPower <= this._bonusPowerMax)
        {
            this._bonusPower += bonus;
            this._sliderPW.value = this._bonusPower;
        }
    }

    public void PowerFine(int fine)
    {
        this._bonusPower -= fine;
        if (this._bonusPower < 0)
            this._bonusPower = 0;
        this._sliderPW.value = this._bonusPower;
    }

    public int DamageCalculation()
    {
        return (int)((this._power + this._weapons[this._weaponsId].Damage) * (100 + this._bonusPower) / 100);
    }
}
