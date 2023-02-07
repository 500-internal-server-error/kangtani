using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sell_Negotiate : MonoBehaviour
{
    public TextMeshProUGUI original_price, negotiation_price;
    public GameObject SellPanel;
    public void backToSellSelect(){
        SellPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Negotiate(){
        int mult = Random.Range(0,10);
        if(GameManager.NegoPrice < GameManager.maxNegoPrice){
            GameManager.GMInstance.GetComponent<GameManager>().Negotiate_Price(mult);
        }
    }

    public void Accept(){
        GameManager.Money += GameManager.NegoPrice;
        backToSellSelect();
    }

    void Update(){
        original_price.text = GameManager.sellPrice.ToString();
        negotiation_price.text = GameManager.NegoPrice.ToString();
    }
}
