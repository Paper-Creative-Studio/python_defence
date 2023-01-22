using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 smoothmove;
    private Vector2 smoothInputVelocity;
    [SerializeField] private float smoothing_speed;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        smoothmove = Vector2.SmoothDamp(smoothmove, input, ref smoothInputVelocity, smoothing_speed);
        
        
        
    }
    private void FixedUpdate()
    {
        rb.velocity = smoothmove * speed;
        Debug.Log(rb.velocity);
    }

}
