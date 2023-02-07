using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Path;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    
    
    
    public Transform controlPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 125f, Vector3.forward);
        Destroy(gameObject, 3);

    }
   
    
}
