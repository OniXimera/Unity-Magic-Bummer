using UnityEngine;

public class AttackState : State
{
    //fix 05.12.2021
    private float _lastAttackTime;
    public override void Action()
    {
        _animator.SetInteger("MoveTip", 0);

        if (_lastAttackTime <= 0)
        {
            _animator.SetTrigger("Attack");
            _lastAttackTime = _enemy.Delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }
    private void Attack()//Animation Event
    {
        _enemy.Target.ApplyDamage(_enemy.Damage);
    }
}
