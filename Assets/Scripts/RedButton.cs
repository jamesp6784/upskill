using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RedButton : MonoBehaviour
{
    [SerializeField]
    private Sprite upSprite;

    [SerializeField]
    private Sprite downSprite;

    [SerializeField]
    private SFX sfx;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerDown()
    {
        image.sprite = downSprite;
        sfx.Play(sfx.buttondown);
    }

    public void OnPointerUp()
    {
        image.sprite = upSprite;
        sfx.Play(sfx.buttonup);
    }
}
