using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public int damage;
    private Rigidbody2D rb;
    
    public float speed;
    public Vector3 target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 dir = target - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Debug.Log(target);
    }

    void Update()
    {
        
        
       
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
