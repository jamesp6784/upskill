using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBehaviour : MonoBehaviour
{
    GameObject master;
    GridManager gridManager;
    GameObject[] grids;

    public float speed;
    public float endY;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        gridManager = master.GetComponent<GridManager>();
        grids = gridManager.GetGrids();

        //Set Spawn
        Vector2 spawnTemp = GetSpawn();
        endY = spawnTemp.y;
        spawnTemp.y += 20;
        transform.position = spawnTemp;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > endY)
        {
            float posY = transform.position.y;
            this.transform.position = new Vector2(transform.position.x, posY -= speed * Time.deltaTime);
        }
    }

    private Vector2 GetSpawn()
    {
        int spawnIndex = Random.Range(0, grids.Length);
        return grids[spawnIndex].transform.position;
    }
}
