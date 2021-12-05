using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyStateMachine), typeof(Animator))]
public class Enemy : MonoBehaviour
{
    //fix 05.12.2021
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
    public int Heal => _maxHeal;
    public int Damage => _damage;
    public float Delay => _attackDelay;
    public float SpeedMove => _speedMove;
    public Player Target => _target;

    private void OnEnable()
    {
        _heal = _maxHeal;
        GetComponent<EnemyStateMachine>().enabled = true;
    }
    public void Init(Player target)
    {
        _target = target;
    }
    public void TakeDamage(int damage)
    {
        _heal -= damage;
        _target.PowerBonus(_playerDamageBonus);

        if (_heal <= 0)
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
