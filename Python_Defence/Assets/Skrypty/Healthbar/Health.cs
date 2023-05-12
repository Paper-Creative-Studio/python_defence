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
    public bool hitable = true;
    movement movescript;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(currentHealth);
        movescript = GetComponent<movement>();
        sprite = GetComponent<SpriteRenderer>();
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
        if(hitable)
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
            
            StartCoroutine(MigajSprite());
        }
        
    }
    private void Roll()
    {
        hitable = false;

    }
    private void StopRoll()
    {
        hitable = true;
        movescript.canRoll= true;
    }
    IEnumerator MigajSprite()
    {
        hitable = false;
        for (int i = 0; i < 5; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.2f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.2f);

        }
        hitable = true;
        
    }
}
