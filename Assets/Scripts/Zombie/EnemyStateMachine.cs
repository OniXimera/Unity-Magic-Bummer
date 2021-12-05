using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private State _idleState;
    [SerializeField] private State[] _stateList;

    private void Update()
    {
        foreach (State state in _stateList)
        {
            if(state.Check())
            {
                state.Action();
                return;
            }
        }

        _idleState.Action();
    }
}
