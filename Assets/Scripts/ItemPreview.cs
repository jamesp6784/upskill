using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreview : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void ChangeSprite(SpriteRenderer otherSprite)
    {
        spriteRenderer.sprite = otherSprite.sprite;

        //Change Alpha
        Color sprColor = otherSprite.color;
        sprColor.a = 0.75f;
        spriteRenderer.color = sprColor;
    }

}
