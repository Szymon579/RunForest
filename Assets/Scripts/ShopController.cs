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
    private int id = 0;

    Transform priceTransform;
    GameObject pricePanel;

    Transform setTransform;
    GameObject setPanel;

    ShopItem shopItem;

    private void Start()
    {
        priceTransform = transform.Find(pricePanelName);
        pricePanel = priceTransform.gameObject;
        pricePanel.SetActive(true);

        setTransform = transform.Find(setPanelName);
        setPanel = setTransform.gameObject;
        setPanel.SetActive(true);

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
        //Debug.Log("update shop controller");
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

    

    public void BuyOrSetItem()
    {   

        if (!shopItem.bought) 
        {
            Debug.Log("BuyItem");
            BuyItem();
        }
        else
        {
            Debug.Log("SetItem");
            SetItem();
        }

        //GameSave.SaveState(new Save(GameState.coins, GameState.items, GameState.selectedId));
    }

    private void BuyItem()
    {

        int price = shopItem.price;
        if (price > GameState.coins)
        {
            Debug.Log("Get money broke boy");
            //SetNotBought();
            return;
        }

        GameState.coins -= price;
        
        shopItem.bought = true;
        GameState.items[id] = shopItem;

        pricePanel.SetActive(false);
        SetBought();
        SetItem();
    }

    private void SetItem()
    {
        setPanel.SetActive(true);
        GameState.selectedId = id;
        GameState.pantsColor = this.gameObject.GetComponent<Image>().color;
    }

    private int GetItemId()
    {
        Debug.Log("Object name" + this.name);
        string strId = this.name[name.Length - 1].ToString();
        Debug.Log("id " + strId);
        return int.Parse(strId);
    }

    private void SetPrice()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = shopItem.price.ToString();
    }

    private void SetColor()
    {
        gameObject.GetComponent<Image>().color = shopItem.color;
    }
}
