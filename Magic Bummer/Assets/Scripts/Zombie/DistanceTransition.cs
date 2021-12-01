using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DistanceTransition : Transition
{
    //fix 30.11.2021
    [SerializeField] private float _distanceLess;
    [SerializeField] private float _distanceIsGreater;
    [SerializeField] private float _rangetSpread;

    private float _distance;
    private void Start()
    {
        this._distanceLess += Random.Range(-this._rangetSpread, this._rangetSpread);
        this._distanceIsGreater += Random.Range(-this._rangetSpread, this._rangetSpread);
        _taget = GetComponent<Enemy>().Target;
    }

    public override bool Check()
    {
        this._distance = Vector2.Distance(transform.position, _taget.transform.position);
        if (this._distance <= this._distanceLess && this._distance >= this._distanceIsGreater)
            return true;
        else
            return false;
    }
}
