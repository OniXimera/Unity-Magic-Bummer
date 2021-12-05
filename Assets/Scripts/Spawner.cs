using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;


public class Spawner : MonoBehaviour
{
    //fix 05.12.2021
    [Header("Parametor")]
    [SerializeField] private GameObject _pool;
    [SerializeField] private GameObject[] _barrierPrefab;
    [SerializeField] private Player _palyer;
    [SerializeField] private TMP_Text _text;

    private int _random;
    private int _kill = 0;
    private int _spawncoint;
    private Dictionary<GameObject, GameObject[]> _dictionaryPrefab = new Dictionary<GameObject, GameObject[]>();

    private void OnDisable()
    {
        foreach (Enemy item in _pool.GetComponentsInChildren<Enemy>())
        {
            item.Deaths -= Kills;
        }
    }

    public void Initialize(Monster[] monsters)
    {
        StartCoroutine(InitializeCorutine(monsters));
    }

    IEnumerator InitializeCorutine(Monster[] monsters)
    {
        GameObject[] spawnedTemp;

        foreach (Monster monster in monsters)
        {
            spawnedTemp = new GameObject[monster.Coutns];

            for (int i = 0; i < monster.Coutns; i++)
            {
                spawnedTemp[i] = Instantiate(monster.Prefab.gameObject, _pool.transform.position, Quaternion.identity, _pool.transform);
                
                if (monster.Prefab.GetComponent<Enemy>())
                {
                    spawnedTemp[i].GetComponent<Enemy>().Init(_palyer);
                    spawnedTemp[i].GetComponent<Enemy>().Deaths += Kills;
                }

                spawnedTemp[i].SetActive(false);
                yield return new WaitForEndOfFrame();
            }
            _dictionaryPrefab.Add(monster.Prefab, spawnedTemp);
        }      
    }

    public void SpawnEnemy(Wave[] waves, Transform[] transforms)
    {
        _spawncoint = _kill = 0;

        foreach (Wave wave in waves)
            foreach (Monster monster in wave.Monsters)
                if(monster.Prefab.GetComponent<Enemy>())
                    _spawncoint += monster.Coutns;

        StartCoroutine(SpawnEnemyCorutine(waves, transforms));
    }

    IEnumerator SpawnEnemyCorutine(Wave[] waves, Transform[] transforms)
    {
        GameObject result;
        Transform point;

        foreach (Wave item in waves)
        {
            foreach (var Monster in item.Monsters)
            {
                for (int i = 0; i < Monster.Coutns; i++)
                {
                    if (Monster.SpawnPoints == null)
                    {
                        if (transforms.Length != 1)
                            _random = Random.Range(0, transforms.Length);
                        else
                            _random = 0;

                        point = transforms[_random];
                    }
                    else 
                    { 
                        point = Monster.SpawnPoints;
                    }

                    while ((result = _dictionaryPrefab[Monster.Prefab].FirstOrDefault(p => p.activeSelf == false)) == null)
                        yield return new WaitForSeconds(Monster.Delay);
                    
                    Spawn(result, point);
                    yield return new WaitForSeconds(Monster.Delay);
                }                
            }
        }
    }

    private void Spawn(GameObject enemy, Transform spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint.position;
    }
    public void Kills(Enemy enemy)
    {
        _kill++;
        _text.text = _spawncoint + " / " + _kill;

        if (_kill == _spawncoint)
        {
            foreach (GameObject item in _barrierPrefab)
            {
                foreach (GameObject barers in _dictionaryPrefab[item])
                {
                    if (barers.activeSelf)
                    {
                        Animator gfdgdf = barers.GetComponentsInChildren<Animator>()[0];
                        gfdgdf.Play("Disable"); 
                    }
                }
            }
        }   
    }
}

[System.Serializable]
public class Wave
{
    public Monster[] Monsters;
    public float Delay;
}

[System.Serializable]
public class Monster
{
    public GameObject Prefab;
    public float Delay;
    public int Coutns;
    public Transform SpawnPoints;
}


