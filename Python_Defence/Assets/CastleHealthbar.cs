using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CastleHealthbar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    // Start is called before the first frame update


    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(int health)
    {
        if(slider != null)
        {

            slider.maxValue = health;
            slider.value = health;
        }

    }
}
