using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperateLadang : MonoBehaviour
{
    private int Growth_Time_Left = 0;
    private bool Ladang_Empty = true, Harvestable = false;
    
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private Sprite BaseSprite;
    //= Resources.Load<Sprite>("");
    public string Crop_Sprite;
    public void AddCrops(){
        Growth_Time_Left = 5;
        Ladang_Empty = false;
    }

    public void CheckCrop(){
        if(Growth_Time_Left == 0 && !Ladang_Empty){
            Harvestable = true;
        }else
        if(Growth_Time_Left > 0 && !Ladang_Empty){
            Growth_Time_Left--;
        }
    }

    private void Harvest(){
        Ladang_Empty = true;
    }

    void Update(){
        if(Growth_Time_Left == 0){
            //SR.sprite
        }else{
            SR.sprite = Resources.Load<Sprite>("./image/"+Crop_Sprite+"/1");
        }
        if (Input.GetMouseButtonUp(0)){

            Vector3 mousePosRaw = Input.mousePosition;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosRaw);
            Vector2 mousePos2 = new Vector2(mousePos.x, mousePos.y);
            
        
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
            Bounds bounds = collider.bounds;
            bool inMouse = bounds.Contains(mousePos2);

            if(inMouse){
                if(Ladang_Empty && !Harvestable){
                    //AddCrops();
                }
                if(Harvestable){
                    //Harvest();
                }
               
            }
            
        }

        switch(Growth_Time_Left){
            case >1:
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            default:
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }

    }

}
