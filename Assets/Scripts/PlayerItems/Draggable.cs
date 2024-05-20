using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] 
    GameObject placedItem;

    [SerializeField] 
    public float itemPrice;

    [SerializeField] 
    public float dropDistance;

    //Private Variables
    bool active;
    GameObject master;
    CardManager cardManager;

    //Grid Management
    GameObject[] grids;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        cardManager = master.GetComponent<CardManager>();
        grids = master.GetComponent<GridManager>().GetGrids();

        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (active)
        {
            this.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PlayerInput();
        }

    }

    private void PlayerInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Left Click");
            active = false;

            GameObject nearestObject = FindNearestObject();
            if (nearestObject != null && Vector2.Distance(this.transform.position, nearestObject.transform.position) < dropDistance && nearestObject.GetComponent<GridSlotDragging>().GetFree())
            {
                Instantiate(placedItem, nearestObject.transform.position, Quaternion.identity);
                nearestObject.GetComponent<GridSlotDragging>().SetFree(false);
                cardManager.cardActive = false;
                Destroy(this.gameObject);
            }
            else
            {
                active = true;
            }
        }
    }

    private GameObject FindNearestObject()
    {
        GameObject nearestObject = null;
        float nearestDistance = dropDistance + 1;

        if (grids != null)
        {
                for (int i = 0; i < grids.Length; i++)
                {
                    float distance = Vector2.Distance(this.transform.position, grids[i].transform.position);

                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        nearestObject = grids[i];
                    }
                }
        }

        Debug.Log("Nearest Distance: " + nearestDistance + "Nearest Object" + nearestObject);
        return nearestObject;
    }

}
