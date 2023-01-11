using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenShop : MonoBehaviour
{
    public GameObject SelectPanel, FarmSeedPanel, FertilizerPanel, InventoryPanel;

    public void ToFarm(){
        FarmSeedPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ToFertilize(){
        FertilizerPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ToFruit(){
        InventoryPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ToSelect(){
        SelectPanel.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
