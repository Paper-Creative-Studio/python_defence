using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Path;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class arrow : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
        Destroy(gameObject, 3);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<Enemy_Health>().TakeDamage(damage);
        }
        Destroy(gameObject);


    }

}
