using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeSkip : MonoBehaviour
{
    public GameManager gm;
    public GameObject BlackScreen;
    //future
    void TriggerRandomEvent(){
        int x = Random.Range(0,100);
        switch(x){
            case < 50://nothing happens
                break;
            case < 60://seed price increase
                break;
            case < 70://Harvest price increase
                break;
            case < 80://Harvest price decrease
                break;
            default://nothing happens
                break;
        }
    }

    void TriggerTimeSkip(){
        
    }
    bool ganjil = true;
    public void Rest(){
        StartCoroutine(fadeBlack(3f));
        if(GameManager.Week >= 4){
            GameManager.Week = 1;
            GameManager.Month++;
            
        }else{
            GameManager.Week++;
        }
        
        if(GameManager.Month > 12){
            GameManager.Month = 1;
            GameManager.Year++;
        }
        if(ganjil) ganjil = false; else ganjil = true;
        
    }
    IEnumerator fadeBlack(float time){
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(time);
        TriggerRandomEvent();
        BlackScreen.SetActive(false);
    }
    private void toBlack(){
        BlackScreen.SetActive(true);
    }
    void Update(){
        
        if (Input.GetMouseButtonUp(0)){

            Vector3 mousePosRaw = Input.mousePosition;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosRaw);
            Vector2 mousePos2 = new Vector2(mousePos.x, mousePos.y);
            
        
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
            Bounds bounds = collider.bounds;
            bool inMouse = bounds.Contains(mousePos2);

            if(inMouse){
                Rest();
                
            }
            
        }
    }
}
