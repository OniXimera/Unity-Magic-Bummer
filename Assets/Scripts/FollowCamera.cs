using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _offset = new Vector3(4, 3, -10);
    [SerializeField] private AnimationCurve _cameraspeed;

    private bool _cameralook;
    private bool _pastDirection;
    private float _timePassed;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _playerPositionOffset;

    private void Start()
    {
        _spriteRenderer = _target.GetComponent<SpriteRenderer>();
        _cameralook = _pastDirection = true;
    }
    
    private void LateUpdate()
    {
        _playerPositionOffset = _target.transform.position + _offset;

        if (_cameralook)
        {
            if (_pastDirection != _spriteRenderer.flipX)
            {
                _cameralook = false;
                _pastDirection = _spriteRenderer.flipX;
                _offset.x = -_offset.x;
                _timePassed = 0;
            }
            else
            { 
                transform.position = _playerPositionOffset; 
            }
        }
        else
        {            
            transform.position = Vector3.MoveTowards(transform.position, _playerPositionOffset, _cameraspeed.Evaluate(_timePassed));   
            
            if (transform.position == _playerPositionOffset)
                _cameralook = true;
            else
                _timePassed += Time.deltaTime;
        }
    }
}
