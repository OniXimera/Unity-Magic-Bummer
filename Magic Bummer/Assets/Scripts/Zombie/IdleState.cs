using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    //fix 30.11.2021
    public override void Action()
    {
        _animator.SetInteger("MoveTip", 0);
    }
}
