using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PythonDefence.Mark;

public class attack : MonoBehaviour
{
    [SerializeField] int damage;
    bool canCheck;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (canCheck)
        {
           
            if (collision.gameObject.layer == 8)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                canCheck = false;
            }
        }
    }
    public void CanCheck()
    {
        canCheck= true;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}