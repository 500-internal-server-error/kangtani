using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGetter : MonoBehaviour
{
    [SerializeField] private GameObject ImageOb;
    
    public void SpriteGetterSetter(Sprite AssignedSprite){
        ImageOb.gameObject.GetComponent<Image>().sprite = AssignedSprite;
    }
    
}
