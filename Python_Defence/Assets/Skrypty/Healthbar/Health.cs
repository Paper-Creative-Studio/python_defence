using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public Healthbar healthbar;
    public UnityEvent onDeath;
    private bool doonce = true;
    public bool alive = true;
    public DeathTrigger deathtrigger;
    public Sprite iconSprite;
    [TextArea]
    public string texttext;
    [TextArea]
    public string tiptext;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(currentHealth);
    }
    private void Update()
    {
        
        if(currentHealth <= 0)
        {
            if(doonce)
            {
                deathtrigger.iconSprite = iconSprite;
                deathtrigger.texttext= texttext;
                deathtrigger.tiptext= tiptext;
                onDeath.Invoke();
                doonce = false;
            }


        }
        else
        {
            doonce = true;
        }
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
