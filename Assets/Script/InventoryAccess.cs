using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAccess : MonoBehaviour
{
    public GameObject inv_Panel;
    bool panel_State = false;
    public void openInventoryPanel(){
        if(!panel_State){
            panel_State = true;
            inv_Panel.gameObject.SetActive(true);
        }else{
            panel_State = false;
            inv_Panel.gameObject.SetActive(false);
        }
    }
}
