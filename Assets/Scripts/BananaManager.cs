using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaManager : MonoBehaviour
{
    Vector2 spawnPosition;

    [SerializeField]
    float lowTimer, highTimer;
    float randTimer;
    [SerializeField]
    float initialSpawnTime;

    [SerializeField]
    GameObject banana;
    int bananaCount;
    bool stopSpawn;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = this.transform.position;
        spawnPosition.y += 20;
        stopSpawn = false;
        StartCoroutine(SpawnBanana());
    }

    private void Update()
    {
        randTimer = Random.Range(lowTimer, highTimer);
    }

    IEnumerator SpawnBanana()
    {
        yield return new WaitForSeconds(initialSpawnTime);

        while (!stopSpawn)
        {   
            if (bananaCount <= 8)
            {
                //Spawn New Banana
                Instantiate(banana, spawnPosition, Quaternion.identity, this.transform);
                bananaCount++;
            }

            yield return new WaitForSeconds(randTimer);
        }
    }
}
