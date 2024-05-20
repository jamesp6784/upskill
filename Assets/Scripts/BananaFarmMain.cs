using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaFarmMain : MonoBehaviour
{
    Vector2 spawn;

    public GameObject banana;
    public float spawnTimer;
    bool bananaSpawned;

    // Start is called before the first frame update
    void Start()
    {
        float posY = transform.position.y;
        spawn = new Vector2(transform.position.x, posY - 0.3f);
        bananaSpawned = false;

        StartCoroutine(SpawnBanana(spawnTimer));
    }

    public void BananaClicked()
    {
        bananaSpawned = false;
    }

    IEnumerator SpawnBanana(float spawnTimer)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            
            if (!bananaSpawned)
            {
                Instantiate(banana, spawn, Quaternion.identity, this.transform);
                bananaSpawned = true;
            }
        }
    }
}
