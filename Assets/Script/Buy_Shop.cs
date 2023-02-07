using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Shop : MonoBehaviour
{
    public GameObject NoticeText;
    public void buy(int item_index){
        bool can = GameManager.GMInstance.GetComponent<GameManager>().canBuy(item_index);
        if(can){
            GameManager.GMInstance.GetComponent<GameManager>().buy_seed(item_index);
        }else{
            StartCoroutine(NoSeed(2f));
        }       
    }
    
    public void buy_padi(){buy(0);}
    public void buy_Jagung(){buy(1);}
    public void buy_Wortel(){buy(2);}

    IEnumerator NoSeed(float time){
        NoticeText.SetActive(true);
        yield return new WaitForSeconds(time);
        NoticeText.SetActive(false);
    }
}
