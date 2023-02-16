using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyarrow : MonoBehaviour
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

        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        Debug.Log(collision.gameObject.layer);
        Destroy(gameObject);


    }
}
