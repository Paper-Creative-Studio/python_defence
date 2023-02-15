using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public int damage;
   
    public float speed;
    private Vector3 playerAlly;
    void start()
    {
        
    }

    void Update()
    {
        playerAlly = GetComponentInParent<Attack_Enemy>().hitPlayer[0].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, playerAlly, speed * Time.fixedDeltaTime);
        Vector3 dir = playerAlly - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       
        Destroy(gameObject, 3);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(gameObject);


    }
}
