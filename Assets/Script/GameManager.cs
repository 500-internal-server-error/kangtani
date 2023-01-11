using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager GMInstance {set;get;}
    public static int Money = 30000, Week = 1, Month = 1, Year = 2022;  private string S_month;
	public static int Wheat_Count = 0, Corn_Count = 0, Carrot_Count = 69;

    private GameObject Display_money, Display_year, Display_month, Display_week, Display_wheat, Display_corn, Display_carrot;

    public int Ladang_Owned = 1;

    void Awake(){
        //Display_money =  GameObject.Find("Money_txt");

        if(GMInstance != null){
            Destroy(this.gameObject);
            return;
        }
        GMInstance = this;
        DontDestroyOnLoad(this);

    }

    private void FindCanvasGameObject(){
        Display_money = GameObject.Find("Money_UI");
        Display_week = GameObject.Find("Week");
        Display_month = GameObject.Find("Month");
        Display_year = GameObject.Find("Year");
		Display_wheat = GameObject.Find("Wheat");
		Display_corn = GameObject.Find("Corn");
		Display_carrot = GameObject.Find("Carrot");
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
    void Update(){
        stringMonth(Month);
        FindCanvasGameObject();
        if(Display_money) Display_money.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Rp. " + Money);
        if(Display_week)  Display_week.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Minggu: " + Week);
        if(Display_month) Display_month.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Bulan: " + S_month);
        if(Display_year)  Display_year.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter("Tahun: " + Year);
		if (Display_wheat) Display_wheat.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter(Wheat_Count.ToString());
		if (Display_corn) Display_corn.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter(Corn_Count.ToString());
		if (Display_carrot) Display_carrot.gameObject.GetComponent<TextGetterSetter>().TMPGetterSetter(Carrot_Count.ToString());
    }
}
