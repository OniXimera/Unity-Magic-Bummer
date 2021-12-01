using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    //fix 30.11.2021
    public override void Action()
    {
        if (transform.position.x < _enemy.Target.transform.position.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(_enemy.Target.transform.position.x, transform.position.y), _enemy.SpeedMove * Time.deltaTime);
        
        _animator.SetInteger("MoveTip", 1);
    }
}
