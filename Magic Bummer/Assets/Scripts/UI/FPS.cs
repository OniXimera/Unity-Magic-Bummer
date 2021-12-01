using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private Text _textFPS;
    [SerializeField] private bool _log;

    private void Update()
    {
        this._textFPS.text = ((int)(1.0f / Time.deltaTime)).ToString();
        if(_log)
            Debug.Log(this._textFPS.text);
    }
}
