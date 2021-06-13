using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    public GameObject enemy;
    float randx;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    private List<Transform> spawnLocations = new List<Transform>();

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] spawnObjects = GameObject.FindGameObjectsWithTag("EnemySpawn");
        Debug.Log(spawnObjects.Length); 

        foreach(GameObject spawner in spawnObjects)
        {
            spawnLocations.Add(spawner.transform);
        }
        Debug.Log(spawnLocations.Count);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawn)
        {
            int randomElement = Random.Range(0, spawnLocations.Count);
            nextSpawn = Time.time + spawnRate;
            Instantiate(enemy, spawnLocations[randomElement].position, Quaternion.identity);
        }
    }
}
