using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSlotDragging : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    bool active;
    bool free;
    Transform playerItem;
    float dragDistance;
    
    [SerializeField]
    GameObject itemPreviewObject;

    ItemPreview itemPreview;
    SpriteRenderer itemPreviewRender;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Item Preview
        itemPreviewObject = gameObject.transform.Find("ItemPreview").gameObject;
        itemPreview = itemPreviewObject.GetComponent<ItemPreview>();
        itemPreviewRender = itemPreviewObject.GetComponent<SpriteRenderer>();
        itemPreviewRender.enabled = false;

        free = true;
    }

    private void Update()
    {
        if (active)
        {
            if (Vector2.Distance(playerItem.position, this.transform.position) < dragDistance)
            {
                itemPreviewRender.enabled = true;
            }
            else
            {
                itemPreviewRender.enabled = false;
            }
        }
        else
        {
            itemPreviewRender.enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerItem"))
        {
            //Player Items
            playerItem = collision.transform;
            dragDistance = collision.gameObject.GetComponent<Draggable>().dropDistance;
            itemPreview.ChangeSprite(playerItem.gameObject.GetComponent<SpriteRenderer>());

            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerItem"))
        {
            active = false;
        }
    }

    public void SetFree(bool free)
    {
        this.free = free;
    }

    public bool GetFree()
    {
        return free;
    }
}
