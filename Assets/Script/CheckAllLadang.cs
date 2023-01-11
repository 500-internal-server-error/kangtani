using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllLadang : MonoBehaviour{
   
    GameObject[] All_Ladang;

    void Awake(){
        All_Ladang = GameObject.FindGameObjectsWithTag("Ladang");
    }
    
    public void UpdateAllLadang(){
        for(int i = 0; i < All_Ladang.Length; i++){
            All_Ladang[i].GetComponent<OperateLadang>().CheckCrop();
        }
    }
    
    void Update(){
        
    }
}
