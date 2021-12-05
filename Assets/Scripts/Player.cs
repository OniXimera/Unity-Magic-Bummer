using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //fix 05.12.2021
    [Header("Character characteristics")]
    [SerializeField] private int _healthMax;
    [SerializeField] private int _manaMax;
    [SerializeField] private int _power;
    [SerializeField] private int _bonusPowerMax;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [Header("Character UI")]
    [SerializeField] private GameObject _gameOverScreen;
    [Header("Character Weapons")]
    [SerializeField] private Weapon[] _weapons;
    [SerializeField] private int _weaponsId;

    public event UnityAction<int, int, int> SliderChange;
    public event UnityAction<int, int, int> SliderMax;

    public Weapon[] Weapons => _weapons;
    public int WeaponsId => _weaponsId;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;

    private int _health;
    private int _mana;
    private int _bonusPower;

    private void Start()
    {
        _health = _healthMax;
        _mana = _manaMax;
        SliderMax?.Invoke(_healthMax, _manaMax, _bonusPowerMax);
        SliderChange?.Invoke(_health, _mana, _bonusPower);
    }
    public void SetWeapons(int weaponId)
    {
        _weaponsId = weaponId;
    }

    public bool ManaCost(int cost)
    {
        if (_mana >= cost)
        {
            _mana -= cost;
            if (_mana >= _manaMax)
                _mana = _manaMax;
            SliderChange?.Invoke(_health, _mana, _bonusPower);
            return true;
        }
        return false;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        SliderChange?.Invoke(_health, _mana, _bonusPower);
        PowerFine(damage);
        if (_health <= 0)
            GameOver();
    }

    public void GameOver()
    {
        _gameOverScreen.SetActive(true);
    }

    public void PowerBonus(int bonus)
    {
        if (_bonusPower <= _bonusPowerMax)
        {
            _bonusPower += bonus;
            SliderChange?.Invoke(_health, _mana, _bonusPower);

        }
    }

    public void PowerFine(int fine)
    {
        _bonusPower -= fine;
        if (_bonusPower < 0)
            _bonusPower = 0;
        SliderChange?.Invoke(_health, _mana, _bonusPower);
    }

    public int DamageCalculation()
    {
        return (int)((_power + _weapons[_weaponsId].Damage) * (100 + _bonusPower) / 100);
    }
}
