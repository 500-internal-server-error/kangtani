using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveBehaviour : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    void Update(){
        //Debug.Log(cam.transform.position);
    }

    public void changePosition(int LoadPosition){
        switch(LoadPosition){
            case 0:
                getPosition(0,0);
                break;
            case 1:
                getPosition(20,0);
                break;
            case 2:
                getPosition(40,0);
                break;
            case 3:
                getPosition(-20,0);
                break;
            default:
                getPosition(0,0);
                break;
            
        }
    }
    private void getPosition(int x, int y){
        cam.transform.position = new Vector3(x,y,-10);
    }

}
