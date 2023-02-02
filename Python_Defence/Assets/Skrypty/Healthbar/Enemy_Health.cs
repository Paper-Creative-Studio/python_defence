using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public Enemy_Healthbar healthbar;
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
            Destroy(transform.parent.gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
