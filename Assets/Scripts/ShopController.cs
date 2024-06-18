using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private string pricePanelName = "PricePanel";
    private string setPanelName = "SetPanel";

    private void Start()
    {
        
    }

    public void BuyOrSetItem()
    {
        Transform priceTransform = transform.Find(pricePanelName);
        GameObject pricePanel = priceTransform.gameObject;
        
        if (pricePanel == null) 
        {
            Debug.Log("Panel is null");
            return;
        }

        if (pricePanel.active) 
        {
            BuyItem();
        }
        else
        {
            SetItem();
        }
     
    }

    private void BuyItem()
    {
        string text = GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(text + " found");

        int price = int.Parse(text);
        if (price > GameState.coins)
        {
            Debug.Log("Get money broke boy");
            return;
        }

        GameState.coins -= price;

        Transform priceTransform = transform.Find(pricePanelName);
        GameObject pricePanel = priceTransform.gameObject;
        pricePanel.SetActive(false);

        SetItem();
    }

    private void SetItem()
    {
        Transform setTransform = transform.Find(setPanelName);
        GameObject setPanel = setTransform.gameObject;
        setPanel.SetActive(true);

        GameState.pantsColor = this.gameObject.GetComponent<Image>().color;
    }
}
