using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell_Shop : MonoBehaviour
{
    public GameObject NoticeText;
    public GameObject NegotiationPanel;
    public void sell(int item_index){
        bool can = GameManager.GMInstance.GetComponent<GameManager>().canSell(item_index);
        if(can){
            //Game manager Sell function
            GameManager.GMInstance.GetComponent<GameManager>().SellIt(item_index);
            NegotiationPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }else{
            StartCoroutine(NoSeed(2f));
        }       

    }
    
    public void sell_padi(){sell(0);}
    public void sell_Jagung(){sell(1);}
    public void sell_Wortel(){sell(2);}

    IEnumerator NoSeed(float time){
        NoticeText.SetActive(true);
        yield return new WaitForSeconds(time);
        NoticeText.SetActive(false);
    }
}
