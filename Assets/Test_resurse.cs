using UnityEngine;

public class Test_resurse : MonoBehaviour
{
    private GameObject prefab;
    void Start()
    {
        prefab = Resources.Load<GameObject>("Prefab/TX Village Old fence");
        Instantiate(prefab, new Vector3(-8.5f, -2.55999994f, 0), Quaternion.identity);
    }

}
