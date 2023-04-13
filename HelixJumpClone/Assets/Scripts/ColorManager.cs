using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] Material safeColor;
    [SerializeField] Material unSafeColor;
    [SerializeField] Material lastRing;

    float s_Hue, s_Saturation, s_Value;
    float u_Hue, u_Saturation, u_Value;

   
    public void ChangeColor()
    {
        s_Hue =  Random.Range(0f,0.7f);
        s_Saturation = Random.Range(0f, 0.6f);
        s_Value = Random.Range(0f, 0.7f);

        u_Hue = Random.Range(0.4f, 1f);
        u_Saturation = Random.Range(0.3f, 1f);
        u_Value = Random.Range(0.2f, 1f);


        safeColor.color = Color.HSVToRGB(s_Hue, s_Saturation, s_Value);
        unSafeColor.color = Color.HSVToRGB(u_Hue, u_Saturation, u_Value);
        lastRing.color = Random.ColorHSV();
    }







}
