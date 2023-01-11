using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextGetterSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AssignedText;
    
    public void TMPGetterSetter(string text){
        AssignedText.text = text;
    }
    
}
