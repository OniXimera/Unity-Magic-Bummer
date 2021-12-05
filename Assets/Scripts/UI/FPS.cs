using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private Text _textFPS;
    [SerializeField] private bool _log;

    private void Update()
    {
        _textFPS.text = ((int)(1.0f / Time.deltaTime)).ToString();

        if(_log)
            Debug.Log(_textFPS.text);
    }
}
