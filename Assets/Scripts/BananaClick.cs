using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaClick : MonoBehaviour
{

    GameObject master;
    CurrencyManager currencyManager;
    GameObject bananaFarm;
    BananaFarmMain bananaFarmMain;
    bool hasParent;


    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master");
        currencyManager = master.GetComponent<CurrencyManager>();

        if (transform.parent.CompareTag("Master"))
        {
            hasParent = false;
        }
        else
        {
            bananaFarm = gameObject.transform.parent.gameObject;
            bananaFarmMain = bananaFarm.GetComponent<BananaFarmMain>();
            hasParent = true;
        }
    }

    void OnMouseOver()
    {
        Debug.Log($"{Input.mousePosition}");
        currencyManager.CollectBanana();

        if (hasParent)
            bananaFarmMain.BananaClicked();

        Destroy(this.gameObject);
    }
}
