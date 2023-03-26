using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float smoothing_speed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashDuration;

    private Vector3 input;
    private Vector3 smoothmove;
    private Vector3 smoothInputVelocity;

    private Rigidbody2D rb;
    [SerializeField] private Animator anim_controller;
    private List<RaycastHit2D> hits = new List<RaycastHit2D>();
    private BoxCollider2D playerCollider;
    private TrailRenderer tr;

    private Health health;

    private bool facingLeft = true;
    public bool moving = true;
    private bool dodging = false;
    private bool canDash = true;
    private bool dashing = false;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health= GetComponent<Health>();
        playerCollider= GetComponent<BoxCollider2D>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.alive)
        {
            if (moving)
            {
                input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") ,0).normalized;
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
                    HandleAnimations();
                }

            }
        }
    }

    private void FixedUpdate()
    {
        if (dashing)
        {
            return;
        }
        if (health.alive)
        {
            Move();
            if(Input.GetKeyDown(KeyCode.LeftShift) && !dodging && canDash)
            {
                StartCoroutine(Dash());
            }
            if(!dodging && canDash)
            {
                Debug.Log("can dash");
            }
            else
            {
                Debug.Log("cant");
            }
        }
    }

    private void Move()
    {
        
        if (moving)
        {
            rb.velocity = smoothmove * speed;
        }
    }

    private void HandleAnimations()
    {
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
    
    void StartDodge()
    {
        dodging = true;
    }

    void StopDodge()
    {
        dodging = false;
    }

    private IEnumerator Dash()
    {
        Debug.Log("dzieje");
        canDash = false;
        dashing = true;
        tr.emitting = true;
        if(input != new Vector3(0,0,0))
        {
            rb.AddForce(input * dashPower);
        }
        else
        {
            rb.AddForce(new Vector2(transform.localScale.x * -1, 0) * dashPower);
        }
        yield return new WaitForSeconds(dashDuration);
        tr.emitting = false;
        dashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
