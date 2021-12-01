using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EnemyStateMachine), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    //fix 30.11.2021
    [Header("Parametr")]
    [SerializeField] private int _maxHeal;
    [SerializeField] private int _damage;
    [SerializeField] [Range(1.3f,99f)] private float _attackDelay;
    [SerializeField] private float _speedMove;
    [Header("Lock")]
    [SerializeField] private Player _target;
    [SerializeField] private int _playerDamageBonus;

    private int _heal;

    public event UnityAction<Enemy> Deaths;
    public int Heal => this._maxHeal;
    public int Damage => this._damage;
    public float Delay => this._attackDelay;
    public float SpeedMove => this._speedMove;
    public Player Target => this._target;

    private void OnEnable()
    {
        this._heal = this._maxHeal;
        GetComponent<EnemyStateMachine>().enabled = true;
    }
    public void Init(Player target)
    {
        this._target = target;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        this._heal -= damage;
        this._target.PowerBonus(_playerDamageBonus);
        if (this._heal <= 0)
        {
            GetComponent<EnemyStateMachine>().enabled = false;
            GetComponent<Animator>().SetTrigger("Death");
        }
    }
    public void Death()//Animation Event
    {
        gameObject.SetActive(false);
        Deaths?.Invoke(this);
    }
}
