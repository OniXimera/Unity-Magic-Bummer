using UnityEngine;

public class Spell : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _damage;
    [SerializeField] private int _mp;

    public Player _player;
    public int Mp => _mp;
    public Sprite Icon => _icon;
    public int DamageCalculation()
    {
        return (int)(_player.DamageCalculation() * _damage);
    }

}
