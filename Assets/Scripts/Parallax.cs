using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    //fix 05.12.2021
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
        _images = GetComponentsInChildren<RawImage>();
        _cameraOldPosition = _camera.transform.position.x;
    }

    private void Update()
    {
        _move = _camera.transform.position.x - _cameraOldPosition;

        if (_move != 0)
        {
            foreach (RawImage rawimage in _images)
            {
                _imagePositionProgres += _parallaxFactor;
                _imagePositionX = rawimage.uvRect.x + (_move * _speed * Time.deltaTime * _imagePositionProgres);
                
                if (_imagePositionX > 1)
                    _imagePositionX -= 1;
                else if(_imagePositionX < -1)
                    _imagePositionX += 1;

                rawimage.uvRect = new Rect(_imagePositionX, 0, rawimage.uvRect.width, rawimage.uvRect.height);
            }

            _imagePositionProgres = 0;
        }

        _cameraOldPosition = _camera.transform.position.x;
    }
}
