using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;

    public Image fill;
    // Start is called before the first frame update
    
    public void setMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;
        fill.color = gradient.Evaluate(1f);
    } 

    public void setAmmo(int ammo)
    {
        slider.value = ammo;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
