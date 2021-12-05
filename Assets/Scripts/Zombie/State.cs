using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Enemy), typeof(SpriteRenderer))]
public class State : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private List<Transition> _transition;
    public List<Transition> Transition => _transition;

    protected Animator _animator;
    protected Enemy _enemy;
    protected SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public bool Check()
    {
        foreach(Transition transitions in _transition)
            if (!transitions.Check())
                return false;

        return true;
    }

    public virtual void Action() 
    { }
}
