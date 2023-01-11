using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMove : MonoBehaviour
{
    [SerializeField] private int Target_Scene;
    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonUp(0)){

            Vector3 mousePosRaw = Input.mousePosition;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosRaw);
            Vector2 mousePos2 = new Vector2(mousePos.x, mousePos.y);
            
        
            BoxCollider2D collider = this.gameObject.GetComponent<BoxCollider2D>();
            Bounds bounds = collider.bounds;
            bool inMouse = bounds.Contains(mousePos2);

            if(inMouse){
                SceneManager.LoadScene(Target_Scene);
            }
            
        }
    }
}
