using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 input;
    private Vector3 smoothmove;
    private Vector3 smoothInputVelocity;
    [SerializeField] private float smoothing_speed;
    [SerializeField] private Animator anim_controller;
    public ContactFilter2D movementFilter;
    public bool moving = true;
    private List<RaycastHit2D> hits = new List<RaycastHit2D>();
    
    private bool facingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moving)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            smoothmove = Vector3.SmoothDamp(smoothmove, input, ref smoothInputVelocity, smoothing_speed);

            if (Input.GetAxisRaw("Horizontal") > 0 && facingLeft)
            {
                Flip();
            }
            if (Input.GetAxisRaw("Horizontal") < 0 && !facingLeft)
            {
                Flip();
            }
            if (Input.GetAxisRaw("Vertical") > 0 && !facingLeft && Input.GetAxisRaw("Horizontal") == 0)
            {
                Flip();
            }

            if (Time.timeScale == 1)
            {
                // triggery animacji
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    anim_controller.SetBool("MovingLeftRight", true);
                    anim_controller.SetBool("MovingUp", false);
                }
                else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") > 0)
                {
                    anim_controller.SetBool("MovingLeftRight", false);
                    anim_controller.SetBool("MovingUp", true);
                }

                else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
                {
                    anim_controller.SetBool("MovingLeftRight", false);
                    anim_controller.SetBool("MovingUp", false);
                }
            }
        
        }
        

    }
    private void FixedUpdate()
    {
        if(moving)
        {
            //rb.MovePosition(transform.position + (smoothmove * speed * Time.fixedDeltaTime));
            bool success = MovePlayer(smoothmove);
            if (!success)
            {
                success = MovePlayer(new Vector2(smoothmove.x, 0));
                if (!success)
                {
                    success = MovePlayer(new Vector2(0, smoothmove.y));
                }
            }
        }
        
    }

    void Flip()
    {
        if(Time.timeScale == 1)
        {
            Vector3 currentscale = gameObject.transform.localScale;
            currentscale.x *= -1;
            gameObject.transform.localScale = currentscale;
            facingLeft = !facingLeft;
        }
        
    }
    bool MovePlayer(Vector3 direction)
    {
        int collisionCount = rb.Cast(direction, movementFilter, hits, speed * Time.fixedDeltaTime + 0.1f);
        if(collisionCount ==0)
        {
            rb.MovePosition(transform.position + (direction * speed * Time.fixedDeltaTime));
            return true;
        }
        else
        {
            
            return false;
        }
    }

}
