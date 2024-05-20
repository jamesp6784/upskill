using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    GameObject uiManager;
    UIEvents uiEvents;
    int currency;
    [SerializeField]
    int score;
    [SerializeField]
    int startCurrency;

    [Header("Card Currencies")]
    [SerializeField]
    public int dartCost;
    [SerializeField]
    public int bananaCost;

    // Start is called before the first frame update
    void Start()
    {
        //Update Currency in UI
        uiManager = GameObject.FindGameObjectWithTag("Interface");
        uiEvents = uiManager.GetComponent<UIEvents>();
        currency = startCurrency;
        uiEvents.UpdateCurrency(currency);
    }

    public void CollectBanana()
    {
        currency += score;
        uiEvents.UpdateCurrency(currency);
    }

    public void PurchaseCard(int cost)
    {
        currency -= cost;
        uiEvents.UpdateCurrency(currency);
    }

    public int GetCurrency()
    {
        return currency;
    }
}
