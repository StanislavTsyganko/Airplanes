using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Класс для управления облаками
public class CloudManager : MonoBehaviour
{
    [SerializeField] public GameObject[] CloudPrefabs;
    public int NumberOfClouds;
    public float CloudSpeed;
    [SerializeField] private Transform[] _spawnPoints;


    private List<GameObject> clouds;

    void Start()
    {
        clouds = new List<GameObject>();
        for (int i = 0; i < NumberOfClouds; i++)
        {
            int num = UnityEngine.Random.Range(0, _spawnPoints.Length-1);
            Transform randomSpawnPoint = _spawnPoints[num];
            GameObject cloud = Instantiate(CloudPrefabs[UnityEngine.Random.Range(0, CloudPrefabs.Length-1)], new Vector3(randomSpawnPoint.transform.position.x+ UnityEngine.Random.Range(0, 50), randomSpawnPoint.transform.position.y, 0), Quaternion.identity);
            clouds.Add(cloud);
        }
    }

    void Update()
    {
        foreach (GameObject cloud in clouds)
        {
            cloud.transform.Translate(new Vector3(-1, UnityEngine.Random.Range(-1f, 1f), 0) * CloudSpeed * Time.deltaTime * Random.Range(0.1f, 1.8f));
            cloud.transform.localScale = new Vector3(2, 2, 2);
            if (cloud.transform.position.x < -100f)
            {
                int num = UnityEngine.Random.Range(0, 6);
                Transform randomSpawnPoint = _spawnPoints[num];
                cloud.transform.position = new Vector3(randomSpawnPoint.transform.position.x, randomSpawnPoint.transform.position.y, 0);
            }
        }
    }
}