using UnityEngine;

public class ParallaxNew : MonoBehaviour
{
    [SerializeField] private float _parallaxEffect;
    [SerializeField] private float _repeatBackground;

    private float _previousCameraPosition, _length;
    private Transform _camera;
    private SpriteRenderer[] _images;
    private Vector2 _imagePosition;
    private void Start()
    {
        _camera = Camera.main.transform;
        _images = GetComponentsInChildren<SpriteRenderer>();
        _previousCameraPosition = _camera.position.x;
        _length = _images[0].GetComponent<SpriteRenderer>().bounds.size.x / transform.localScale.x / _repeatBackground;
    }

    private void FixedUpdate()
    {
        if (_previousCameraPosition == _camera.position.x)
        {
            return;
        }

        for (int i = 0; i < _images.Length; i++)
        {
            _imagePosition = _images[i].transform.localPosition;
            _imagePosition = new Vector2(_imagePosition.x - ((_camera.position.x - _previousCameraPosition) * (_parallaxEffect * (i + 1))), _imagePosition.y);

            if (_imagePosition.x > _length)
            {
                _imagePosition = new Vector2(_imagePosition.x - _length, _imagePosition.y);
            }
            else if (_imagePosition.x < -_length)
            {
                _imagePosition = new Vector2(_imagePosition.x + _length, _imagePosition.y);
            }
            _images[i].transform.localPosition = _imagePosition;
        }
        _previousCameraPosition = _camera.position.x;
    }
}
