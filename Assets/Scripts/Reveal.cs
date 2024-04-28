using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reveal : MonoBehaviour
{
    public Image blocker1;
    public Image blocker2;

    public SFX sfx;

    private bool revealed = false;

    public void OnRevealPress()
    {
        if (revealed)
        {
            return;
        }

        revealed = true;
        StartCoroutine(DoReveal());
    }

    private IEnumerator DoReveal()
    {
        GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(2f);

        sfx.Play(sfx.spotlight);
        yield return new WaitForSeconds(0.1f);
        blocker1.enabled = false;

        yield return new WaitForSeconds(3f);
        sfx.Play(sfx.spotlight);
        yield return new WaitForSeconds(0.1f);
        blocker2.enabled = false;
    }
}
