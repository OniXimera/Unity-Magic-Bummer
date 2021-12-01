using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    //fix 30.11.2021
    private float _lastAttackTime;
    public override void Action()
    {
        _animator.SetInteger("MoveTip", 0);
        if (this._lastAttackTime <= 0)
        {
            _animator.SetTrigger("Attack");
            this._lastAttackTime = _enemy.Delay;
        }
        this._lastAttackTime -= Time.deltaTime;
    }
    private void Attack()//Animation Event
    {
        _enemy.Target.ApplyDamage(_enemy.Damage);
    }
}
