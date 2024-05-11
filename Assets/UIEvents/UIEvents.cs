using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIEvents : MonoBehaviour
{

    private UIDocument uiDocument;
    private Button dartButton;
    private Button bananaButton;
    private Label currency;
    [SerializeField] GameObject bananaButtonItem;
    [SerializeField] GameObject dartButtonItem;

    //Currency Labels
    private Label bananaCurrency;
    private Label dartCurrency;

    GameObject master;
    CurrencyManager currencyManager;
    CardManager cardManager;

    private Vector2 spawnInit;
    

    // Start is called before the first frame update
    void Awake()
    {
        //Set Game Objects
        master = GameObject.FindGameObjectWithTag("Master");
        currencyManager = master.GetComponent<CurrencyManager>();
        cardManager = master.GetComponent<CardManager>();
        spawnInit = new Vector2(-50, -50);

        //Set UI Elements
        uiDocument = GetComponent<UIDocument>();

        //Set Up Currency Counter
        currency = uiDocument.rootVisualElement.Q("currencylabel") as Label;

        //Set Up Banana Button
        bananaButton = uiDocument.rootVisualElement.Q("bananacard") as Button;
        bananaButton.RegisterCallback<ClickEvent>(OnBananaClick);
        bananaCurrency = uiDocument.rootVisualElement.Q("bananacurrency") as Label;
        bananaCurrency.text = currencyManager.bananaCost.ToString();

        //Set Up Dart Button
        dartButton = uiDocument.rootVisualElement.Q("dartcard") as Button;
        dartButton.RegisterCallback<ClickEvent>(OnDartClick);
        dartCurrency = uiDocument.rootVisualElement.Q("dartcurrency") as Label;
        dartCurrency.text = currencyManager.dartCost.ToString();
    }

    public void UpdateCurrency(int score)
    {
        currency.text = score.ToString();
    }

    private void OnDartClick(ClickEvent evt)
    {
        if (currencyManager.GetCurrency() >= currencyManager.dartCost)
        {
            SpawnCard(dartButtonItem, currencyManager.dartCost);
        }
    }

    private void OnBananaClick(ClickEvent evt)
    {
        if (currencyManager.GetCurrency() >= currencyManager.bananaCost)
        {
            SpawnCard(bananaButtonItem, currencyManager.bananaCost);
        }
    }

    private void SpawnCard(GameObject card, int cost)
    {
        if (!cardManager.cardActive)
        {
            currencyManager.PurchaseCard(cost);
            cardManager.cardActive = true;
            Instantiate(card, spawnInit, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        dartButton.UnregisterCallback<ClickEvent>(OnDartClick);
        bananaButton.UnregisterCallback<ClickEvent>(OnBananaClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
