using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButton : MonoBehaviour{

   
    public void StartGame(){
        Debug.Log("Game should start");
        SceneManager.LoadScene(0);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
