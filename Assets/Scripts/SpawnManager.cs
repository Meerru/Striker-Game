using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject firstEnemyPrefab;

    [SerializeField]
    private GameObject secondEnemyPrefab;

    [SerializeField]
    private GameObject thirdEnemyPrefab;

    [SerializeField]
    private float firstEnemyInterval = 3.5f;

    [SerializeField]
    private float secondEnemyInterval = 5.0f;

    [SerializeField]
    private float thirdEnemyInterval = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(firstEnemyInterval, firstEnemyPrefab));
        StartCoroutine(spawnEnemy(secondEnemyInterval, secondEnemyPrefab));
        StartCoroutine(spawnEnemy(thirdEnemyInterval, thirdEnemyPrefab));

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
