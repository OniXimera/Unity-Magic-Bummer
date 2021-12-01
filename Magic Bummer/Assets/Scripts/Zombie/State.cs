using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Enemy), typeof(SpriteRenderer))]
public class State : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private List<Transition> _transition;
    public List<Transition> Transition => this._transition;

    protected Animator _animator;
    protected Enemy _enemy;
    protected SpriteRenderer _spriteRenderer;

    private void Start()
    {
        this._animator = GetComponent<Animator>();
        this._enemy = GetComponent<Enemy>();
        this._spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public bool Check()
    {
        foreach(Transition transitions in this._transition)
            if (!transitions.Check())
                return false;
        return true;
    }

    public virtual void Action() 
    { }
}
