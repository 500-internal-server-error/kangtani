using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenShop : MonoBehaviour
{
    public GameObject SelectPanel, FarmSeedPanel, FertilizerPanel, FruitSeedPanel, SellPanel;
    
    public void ToFarm(){
        FarmSeedPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ToFertilize(){
        FertilizerPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ToFruit(){
        FruitSeedPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ToSelect(){
        SelectPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ToSell(){
        SellPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
