using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    //fix 05.12.2021
    [SerializeField] private string _loadLevel;
    [SerializeField] private GameObject _gameObject;

    public void OnLoadButtonClick()
    {
        _gameObject.SetActive(true);
        StartCoroutine(LoadCoroutine());
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    IEnumerator LoadCoroutine()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_loadLevel);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
