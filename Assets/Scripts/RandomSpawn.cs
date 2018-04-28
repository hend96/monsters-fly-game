using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    int randEnemy;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = UnityEngine.Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            randEnemy = UnityEngine.Random.Range(0, 6);
            Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), 3f, UnityEngine.Random.Range(-spawnValues.z, spawnValues.z));
            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(2);
        }
    }
}
