using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField]
    float lowSpawn, highSpawn, initialSpawn;
    float randSpawn;

    public int maxEnemy;
    int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTime());
    }

    private void Update()
    {
        randSpawn = Random.Range(lowSpawn, highSpawn);
    }

    IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(initialSpawn);

        while (true)
        {  
            if (enemyCount < maxEnemy)
            {
                Instantiate(enemy, this.transform.position, Quaternion.identity, this.transform);
                enemyCount++;
            }

            yield return new WaitForSeconds(randSpawn);
        }
    }
}
