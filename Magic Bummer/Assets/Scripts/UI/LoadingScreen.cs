using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    //fix 30.11.2021
    [SerializeField] private string _loadLevel;
    [SerializeField] private GameObject _gameObject;

    public void OnLoadButtonClick()
    {
        this._gameObject.SetActive(true);
        StartCoroutine(LoadCoroutine());
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    IEnumerator LoadCoroutine()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(this._loadLevel);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
