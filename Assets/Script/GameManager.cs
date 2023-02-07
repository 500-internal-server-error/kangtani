using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager GMInstance {set;get;}
    public static int Money = 30000, Week = 1, Month = 1, Year = 2022, Rent = 25000;  
    private string S_month;

    private GameObject Display_money, Display_year, Display_month, Display_week;

    public int Ladang_Owned = 1;

    private bool fill_Plant = false; 

    public int Sell_Multiplier = 1, Buy_Multiplier = 1; 
    void Awake(){
        //Display_money =  GameObject.Find("Money_txt");

        if(GMInstance != null){
            Destroy(this.gameObject);
            return;
        }
        GMInstance = this;
        DontDestroyOnLoad(this);
        if(!fill_Plant){
            fill_Inventory();
        }
    }

    public struct Plants{
        public string Plant_Name;
        public int Plant_Growth_Time, Plant_sell_Price, Plant_seed_Price;
        public Sprite Plant_Sprite;
        public int Plant_Owned, Plant_seed_Owned;

        public void Plant_Setter(int x){Plant_Owned = x;}
        public void Seed_Setter(int x){Plant_seed_Owned = x;}
    } 
    public static Plants[] pln = new Plants[3];

    private void fill_Inventory(){
        pln[0].Plant_Name = "Padi"  ;pln[0].Plant_Growth_Time = 5;pln[0].Plant_Setter(1);pln[0].Seed_Setter(1); pln[0].Plant_Sprite = Resources.Load<Sprite>("Image/Corps/padi1-trans");
        pln[1].Plant_Name = "Jagung";pln[1].Plant_Growth_Time = 4;pln[1].Plant_Setter(0);pln[1].Seed_Setter(0); pln[1].Plant_Sprite = Resources.Load<Sprite>("Image/Corps/jagung1-trans");
        pln[2].Plant_Name = "Wortel";pln[2].Plant_Growth_Time = 3;pln[2].Plant_Setter(0);pln[2].Seed_Setter(0); pln[2].Plant_Sprite = Resources.Load<Sprite>("Image/Corps/wortel1-trans");
    }

    private void FindCanvasGameObject(){
        Display_money = GameObject.Find("Money_UI");
        Display_week = GameObject.Find("Week");
        Display_month = GameObject.Find("Month");
        Display_year = GameObject.Find("Year");
    }
    void stringMonth(int m){
        switch(m){
            case 1: S_month = "Januari"; break;
            case 2: S_month = "Februari"; break;
            case 3: S_month = "Maret"; break;
            case 4: S_month = "April"; break;
            case 5: S_month = "Mei"; break;
            case 6: S_month = "Juni"; break;
            case 7: S_month = "Juli"; break;
            case 8: S_month = "Agustus"; break;
            case 9: S_month = "September"; break;
            case 10: S_month = "Oktober"; break;
            case 11: S_month = "November"; break;
            case 12: S_month = "Desember"; break;
            default: S_month = "Out of Bound"; break;
        }
    }
    
    public static Sprite Field_Sprite;
    
    public Sprite Sprite_Def;

    public static int Growth_Time_Left = 0, Full_Growth_Time = 0, Plant_index = -1;

    void Update(){
        
        pln[0].Plant_sell_Price = 3000 * Sell_Multiplier; pln[0].Plant_seed_Price = 1000 * Buy_Multiplier; 
        pln[1].Plant_sell_Price = 2000 * Sell_Multiplier; pln[1].Plant_seed_Price = 1000 * Buy_Multiplier; 
        pln[2].Plant_sell_Price = 5000 * Sell_Multiplier; pln[2].Plant_seed_Price = 2000 * Buy_Multiplier; 

        stringMonth(Month);
        FindCanvasGameObject();
        if(Display_money) Display_money.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Rp. " + Money);
        if(Display_week)  Display_week.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Minggu: " + Week);
        if(Display_month) Display_month.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Bulan: " + S_month);
        if(Display_year)  Display_year.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Tahun: " + Year);

        if(Growth_Time_Left == 0 && Full_Growth_Time == 0){
            //Default
            Field_Sprite = Sprite_Def;
        }else if(Growth_Time_Left == Full_Growth_Time){
            //Plant
            Field_Sprite = Resources.Load<Sprite>("Image/"+pln[Plant_index].Plant_Name+"/1"); 
        }else if(Growth_Time_Left > 0 && Growth_Time_Left < Full_Growth_Time){
            //Growing
            Field_Sprite = Resources.Load<Sprite>("Image/"+pln[Plant_index].Plant_Name+"/2");
        }else if(Growth_Time_Left == 0 && Full_Growth_Time != 0){
            //Harvestable
            Field_Sprite = Resources.Load<Sprite>("Image/"+pln[Plant_index].Plant_Name+"/3"); 
        }
    }


    //plant - Field
    public Sprite GetInvSprite(int id){
        return pln[id].Plant_Sprite;
    }
        
    public void GetCrop(int cg){
        pln[Plant_index].Plant_Owned += cg;
        Debug.Log("owned = " + pln[Plant_index].Plant_Owned);
    }
    public int checkSeed(int Pindex){
        return pln[Pindex].Plant_seed_Owned;
    }
    public void GrowCrop(int Pindex){
        Growth_Time_Left = pln[Pindex].Plant_Growth_Time;
        Full_Growth_Time = pln[Pindex].Plant_Growth_Time;
        Plant_index = Pindex;
        pln[Pindex].Plant_seed_Owned--;
    }
    
    //buy - Shop
    public void buy_seed(int Sindex){
        pln[Sindex].Plant_seed_Owned++;
        Money -= pln[Sindex].Plant_seed_Price;
    }
    public bool canBuy(int Sindex){
        return Money > pln[Sindex].Plant_seed_Price;
    }

    //sell - Shop
    public static int sellPrice, sellingIndex, NegoPrice, maxNegoPrice = 0;
    int maxNegoMult;
    public void SellIt(int Sindex){
        sellingIndex = Sindex;
        sellPrice = pln[Sindex].Plant_Owned * pln[Sindex].Plant_sell_Price;
        NegoPrice = sellPrice;
        maxNegoMult = Random.Range(30,50);
        maxNegoPrice = sellPrice * (100 + maxNegoMult) / 100;
    }
    public bool canSell(int Sindex){
        return pln[Sindex].Plant_Owned > 0;
    }

    public void Negotiate_Price(int multiplier){
        NegoPrice = NegoPrice * (100 + maxNegoMult) / 100;
    }
}
