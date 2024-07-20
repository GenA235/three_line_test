using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
   public Image Filled;
   public Text Text;

   public void HealthValueChanged(float fill, string text){
    Filled.fillAmount = fill;
    if(Text!=null) Text.text = text;
   }
}
