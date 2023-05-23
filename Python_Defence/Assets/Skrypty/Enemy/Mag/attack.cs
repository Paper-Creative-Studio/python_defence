using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    [SerializeField] int damage;
    bool canCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("przed");
        if (canCheck)
        {
            Debug.Log("pog");
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
