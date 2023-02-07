using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field_Inventory : MonoBehaviour{

    public GameObject Field, NoticeText;
    //public GameObject FieldPanel;
    //public GameObject PI;
    private int checkVal;

    public void Tanam(int dex){
        checkVal = GameManager.GMInstance.GetComponent<GameManager>().checkSeed(dex);
        if(checkVal > 0){
            Field.GetComponent<OperateLadang>().AddCrops(dex);
        }else{
            StartCoroutine(NoSeed(2f));
        }
        Exit_Panel();
    }

    public void Tanam_Padi(){Tanam(0);}
    public void Tanam_Jagung(){Tanam(1);}
    public void Tanam_Wortel(){Tanam(2);}

    public void Exit_Panel(){
        this.gameObject.SetActive(false);
    }

    IEnumerator NoSeed(float time){
        NoticeText.SetActive(true);
        yield return new WaitForSeconds(time);
        NoticeText.SetActive(false);
    }
}
