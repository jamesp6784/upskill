using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private GameObject[] grids;

    [SerializeField]
    GameObject grid;
    [SerializeField]
    int width, height;
    [SerializeField]
    float widthSpacing, heightSpacing;
    [SerializeField]
    Vector2 startPosition;
    [SerializeField]
    Color gridA; 
    [SerializeField]
    Color gridB;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        grids = GameObject.FindGameObjectsWithTag("Grid");
    }

    private void GenerateGrid()
    {
        startPosition = this.transform.position;
        bool colorBool = true;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnGrid = Instantiate(grid, new Vector2(x + widthSpacing + startPosition.x, y + heightSpacing + startPosition.y), Quaternion.identity, this.transform);

                //Set Color
                if (colorBool)
                {
                    spawnGrid.GetComponent<SpriteRenderer>().color = gridA;
                }
                else
                {
                    spawnGrid.GetComponent<SpriteRenderer>().color = gridB;
                }
                colorBool = !colorBool;

                //Set Name
                spawnGrid.name = $"Grid {x} {y}";
            }
        }
    }

    public GameObject[] GetGrids()
    {
        return grids;
    }
}
