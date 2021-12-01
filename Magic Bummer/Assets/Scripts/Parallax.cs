using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private float _speed;
    [SerializeField] private float _parallaxFactor;
    [SerializeField] private Camera _camera;

    private RawImage[] _images;
    private float _imagePositionX;
    private float _imagePositionProgres;
    private float _cameraOldPosition;
    private float _move;

    private void Start()
    {
        this._images = GetComponentsInChildren<RawImage>();
        this._cameraOldPosition = this._camera.transform.position.x;
    }

    private void Update()
    {
        this._move = this._camera.transform.position.x - this._cameraOldPosition;
        if (this._move != 0)
        {
            foreach (RawImage rawimage in this._images)
            {
                this._imagePositionProgres += this._parallaxFactor;

                this._imagePositionX = rawimage.uvRect.x + (this._move * this._speed * Time.deltaTime * this._imagePositionProgres);
                if (this._imagePositionX > 1)
                    this._imagePositionX -= 1;
                else if(this._imagePositionX < -1)
                    this._imagePositionX += 1;
                rawimage.uvRect = new Rect(this._imagePositionX, 0, rawimage.uvRect.width, rawimage.uvRect.height);
            }
            this._imagePositionProgres = 0;
        }
        this._cameraOldPosition = this._camera.transform.position.x;
    }
}
