using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperateLadang : MonoBehaviour
{
    private int Growth_Time_Left = 0, Full_Growth_Time = 0;
    private bool Harvestable = false;
    
    public GameObject Inventory_Panel;

    //[SerializeField] private SpriteRenderer SR;
    //[SerializeField] private Sprite Default_Sprite;
    //= Resources.Load<Sprite>("");
    //public Sprite Crop_Sprite1, Crop_Sprite2, Crop_Sprite3;


    

    public void AddCrops(int plant){
        crop_gained = 0;
        GameManager.GMInstance.GetComponent<GameManager>().GrowCrop(plant);
    }

    public void CheckCrop(){
        if(Growth_Time_Left > 0 &&  Full_Growth_Time != 0){
            Growth_Time_Left--;
        }
    }
    public int crop_gained = 0;
    private void Harvest(){
        GameManager.Full_Growth_Time = 0;
        Harvestable = false;
        crop_gained = Random.Range(3,7);
        GameManager.GMInstance.GetComponent<GameManager>().GetCrop(crop_gained);
    }

    void Update(){
        //SR.sprite = GameManager.Field_Sprite;

        // if(Growth_Time_Left == 0 && !Harvestable){
        //     SR.sprite = Default_Sprite;
        // }else
        // if(Growth_Time_Left == Full_Growth_Time){
        //     //string x = "Resource/Image/"+Crop_Sprite+"/1.png";
        //     //Debug.Log(x);
        //     SR.sprite = Crop_Sprite1;
            
        // }else
        // if(Growth_Time_Left > 0 && Growth_Time_Left < Full_Growth_Time){
        //     //SR.sprite = Resources.Load<Sprite>("Resource/Image/"+Crop_Sprite+"/2");
        //     SR.sprite = Crop_Sprite2;
        // }else
        // if(Growth_Time_Left == 0 && Harvestable){
        //     //SR.sprite = Resources.Load<Sprite>("Resource/Image/"+Crop_Sprite+"/3");
        //     SR.sprite = Crop_Sprite3;
        // }
                
        this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Field_Sprite;

        Full_Growth_Time = GameManager.Full_Growth_Time;
        Growth_Time_Left = GameManager.Growth_Time_Left;

        if(Growth_Time_Left == 0 && Full_Growth_Time != 0){
            Harvestable = true;
        }

        if (Input.GetMouseButtonUp(0)){

            Vector3 mousePosRaw = Input.mousePosition;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosRaw);
            Vector2 mousePos2 = new Vector2(mousePos.x, mousePos.y);
            
        
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
            Bounds bounds = collider.bounds;
            bool inMouse = bounds.Contains(mousePos2);

            if(inMouse){
                if(Harvestable){
                    Harvest();
                }

                if(Full_Growth_Time == 0 && !Harvestable){
                    Inventory_Panel.SetActive(true);
                }                 
            }
            
        }

        // switch(Growth_Time_Left){
        //     case >1:
        //         this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        //         break;
        //     case 1:
        //         this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        //         break;
        //     case 0:
        //         this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        //         break;
        //     default:
        //         this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        //         break;
        // }

    }

}
