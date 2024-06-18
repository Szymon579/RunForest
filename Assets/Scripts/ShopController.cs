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
    private int id = -1;

    Transform priceTransform;
    GameObject pricePanel;

    Transform setTransform;
    GameObject setPanel;

    ShopItem shopItem;

    private void Start()
    {
        priceTransform = transform.Find(pricePanelName);
        pricePanel = priceTransform.gameObject;

        setTransform = transform.Find(setPanelName);
        setPanel = setTransform.gameObject;

        GameSave.LoadState();

        id = GetItemId();
        shopItem = GameState.items[id];

        SetColor();
        SetPrice();
        
        if (shopItem.bought)
        {
            SetBought();
        }
        else
        {
            SetNotBought();
        }

    }

    private void Update()
    {
        if(shopItem.bought && id == GameState.selectedId) 
        {
            setPanel.SetActive(true);
        }
        else
        {
            setPanel.SetActive(false);
        }
    }

    private void SetBought()
    {
        pricePanel.SetActive(false);
        
        if(id == GameState.selectedId) 
        {
            setPanel.SetActive(true);
        }
        
    }

    private void SetNotBought()
    {
        pricePanel.SetActive(true);
        setPanel.SetActive(false);
    }

    private void SetPrice()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = shopItem.price.ToString();
    }

    private void SetColor()
    {
        gameObject.GetComponent<Image>().color = shopItem.color;
    }

    private int GetItemId()
    {
        Debug.Log("Object name" + this.name);
        string strId = this.name[name.Length - 1].ToString();
        Debug.Log("id " + strId);
        return int.Parse(strId);
    }

    public void BuyOrSetItem()
    {   
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

        int price = shopItem.price;
        if (price > GameState.coins)
        {
            Debug.Log("Get money broke boy");
            return;
        }

        GameState.coins -= price;
        GameState.items[id].bought = true;

        pricePanel.SetActive(false);

        SetItem();
    }

    private void SetItem()
    {
        setPanel.SetActive(true);
        GameState.selectedId = id;
        GameState.pantsColor = this.gameObject.GetComponent<Image>().color;
    }
}
