using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Main : MonoBehaviour
{
    public Spinner spinner1;
    public Spinner spinner2;
    public Spinner spinner3;

    public SFX sfx;

    public VideoPlayer winVideo;


    private bool spinning = false;
    private bool canPress = true;
    private bool cheating = false;

    private void Start()
    {
        winVideo.Prepare();
    }

    public void OnButtonClick()
    {
        if (!canPress)
        {
            return;
        }

        StartCoroutine(ToggleSpin());
    }

    public void Cheat()
    {
        cheating = true;
    }

    private IEnumerator ToggleSpin()
    {
        canPress = false;
        spinning = !spinning;

        yield return StartCoroutine(spinning ? StartSpin() : StopSpin());

        canPress = true;
    }

    private IEnumerator StartSpin()
    {
        foreach (var sp in GetSpinners())
        {
            yield return new WaitForSeconds(0.1f);
            sp.StartSpin();
        }

        yield return new WaitForSeconds(0.5f);
    }

    private IEnumerator StopSpin()
    {
        var hasWon = true;

        foreach (var sp in GetSpinners())
        {
            var num = cheating ? 7 : Random.Range(0, 9);
            yield return sp.StopAt(num);
            hasWon &= num == 7;
        }

        if (hasWon)
        {
            sfx.Play(sfx.bigwin);
            winVideo.Play();
        }
        else
        {
            sfx.Play(sfx.wrong);
        }

        cheating = false;

        yield return new WaitForSeconds(0.5f);
    }

    private System.Collections.Generic.IEnumerable<Spinner> GetSpinners()
    {
        yield return spinner1;
        yield return spinner2;
        yield return spinner3;
    }
}
