using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowCamera : MonoBehaviour
{
    //fix 30.11.2021
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
        this._spriteRenderer = this._target.GetComponent<SpriteRenderer>();
        this._cameralook = this._pastDirection = true;
    }
    
    private void LateUpdate()
    {
        this._playerPositionOffset = this._target.transform.position + this._offset;

        if (this._cameralook)
        {
            if (this._pastDirection != this._spriteRenderer.flipX)
            { 
                this._cameralook = false;
                this._pastDirection = this._spriteRenderer.flipX;
                this._offset.x = -this._offset.x;
                this._timePassed = 0;
            }
            else
                transform.position = this._playerPositionOffset; 
        }
        else
        {            
            transform.position = Vector3.MoveTowards(transform.position, this._playerPositionOffset, this._cameraspeed.Evaluate(this._timePassed));   
            
            if (transform.position == this._playerPositionOffset)
                this._cameralook = true;
            else
                this._timePassed += Time.deltaTime;
        }
    }
}
