using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    [SerializeField] private string _adres;

    private void Start()
    {
        Instantiate(Resources.Load<GameObject>(_adres), transform.position, transform.rotation, transform);
    }

}
