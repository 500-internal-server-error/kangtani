using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private int item_ID;
    //[SerializeField] private Image img;
    //public Sprite inv_Sprite;
    public int x;

    private GameObject Display_Name, Display_Price, Display_Owned, Display_seed_Owned, img;

    //ambil struct 
    GameManager.Plants inv_pln = new GameManager.Plants();

    private void FindInventoryDisplay(){
        img = GameObject.Find("Item_"+inv_pln.Plant_Name);
        Display_Name = GameObject.Find("Name_"+inv_pln.Plant_Name);
        Display_Price = GameObject.Find("Price_"+inv_pln.Plant_Name);
        Display_Owned = GameObject.Find("Owned_"+inv_pln.Plant_Name);
        Display_seed_Owned = GameObject.Find("Seed_"+inv_pln.Plant_Name);
    }

    void Update(){
        inv_pln = GameManager.pln[item_ID];
        x = item_ID;
        FindInventoryDisplay();
        if(img) img.gameObject.GetComponent<SpriteGetter>().SpriteGetterSetter(inv_pln.Plant_Sprite);
        if(Display_Name) Display_Name.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter(""+inv_pln.Plant_Name);
        if(Display_Price) Display_Price.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Rp. " + inv_pln.Plant_sell_Price);
        if(Display_Owned) Display_Owned.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Tersimpan: " + inv_pln.Plant_Owned);
        if(Display_seed_Owned) Display_seed_Owned.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Biji: " + inv_pln.Plant_seed_Owned);
        
    }
}
