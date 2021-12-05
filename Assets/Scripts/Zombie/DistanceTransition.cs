using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DistanceTransition : Transition
{
    //fix 05.12.2021
    [SerializeField] private float _distanceLess;
    [SerializeField] private float _distanceIsGreater;
    [SerializeField] private float _rangetSpread;

    private float _distance;
    private void Start()
    {
        _distanceLess += Random.Range(-_rangetSpread, _rangetSpread);
        _distanceIsGreater += Random.Range(-_rangetSpread, _rangetSpread);
        _taget = GetComponent<Enemy>().Target;
    }

    public override bool Check()
    {
        _distance = Vector2.Distance(transform.position, _taget.transform.position);

        if (_distance <= _distanceLess && _distance >= _distanceIsGreater)
            return true;
        else
            return false;
    }
}
