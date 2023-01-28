using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_Healthbar : MonoBehaviour
{
    [SerializeField] private Transform enemy;
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
       
       
    }
    private void Update()
    {
        transform.position = enemy.transform.position + new Vector3(-0.1f, 0.75f, 0);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
}

