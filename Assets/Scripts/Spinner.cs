using System.Collections;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private static float maxSpeed = 800f;
    private static float accelerationTime = 0.4f;
    private static float numHeight = 70.07f;
    private static float numPadding = 1.55f;
    private static float totalHeight = (numHeight * 11) + (numPadding * 10);

    private RectTransform rt;

    private Coroutine spinCoroutine;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void StartSpin()
    {
        StopSpinCoroutine();
        spinCoroutine = StartCoroutine(Spin());
    }

    public IEnumerator StopAt(int number)
    {
        var lastYPos = rt.anchoredPosition.y;

        while (rt.anchoredPosition.y >= lastYPos)
        {
            lastYPos = rt.anchoredPosition.y;
            yield return null;
        }

        var numberPos = CalcNumberPos(number);

        while (rt.anchoredPosition.y < numberPos)
        {
            yield return null;
        }

        StopSpinCoroutine();

        var pos = rt.anchoredPosition;
        pos.y = numberPos;
        rt.anchoredPosition = pos;
    }

    private void StopSpinCoroutine()
    {
        if (spinCoroutine != null)
        {
            StopCoroutine(spinCoroutine);
            spinCoroutine = null;
        }
    }

    private IEnumerator Spin()
    {
        var currentSpeed = 0f;
        var startTime = Time.time;

        while (true)
        {
            var p = rt.anchoredPosition;

            p.y = (p.y + (currentSpeed * Time.deltaTime)) % (totalHeight - numHeight);

            rt.anchoredPosition = p;

            currentSpeed = Mathf.Lerp(0f, maxSpeed, (Time.time - startTime) / accelerationTime);

            yield return null;
        }
    }

    private static float CalcNumberPos(int number)
    {
        return (numHeight + numPadding) * number;
    }
}
