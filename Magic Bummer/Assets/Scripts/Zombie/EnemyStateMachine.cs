using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private State _idleState;
    [SerializeField] private State[] _stateList;

    private void Update()
    {
        foreach (State state in this._stateList)
        {
            if(state.Check())
            {
                state.Action();
                return;
            }
        }
        this._idleState.Action();

    }
}
