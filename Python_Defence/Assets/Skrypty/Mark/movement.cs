using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Slider dashSlider;

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
        if (dashing)
        {
            return;
        }
        if (health.alive)
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
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    anim_controller.SetTrigger("Roll");
                    
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && !dodging && canDash && dashSlider.value == 0)
            {
                StartCoroutine(Dash());
                dashSlider.value = dashSlider.maxValue;
                StartCoroutine(SliderCooldown());
            }
        }
    }

    private void FixedUpdate()
    {
        if(dashing)
        {
            return;
        }
        if (health.alive)
        {
            Move();
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
            if (!health.hitable)
            {
                anim_controller.SetBool("MovingLeftRight", false);
                anim_controller.SetBool("MovingUp", false);
                anim_controller.SetBool("MovingDown", false);
            }
            else
            {
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    anim_controller.SetBool("MovingLeftRight", true);
                    anim_controller.SetBool("MovingUp", false);
                    anim_controller.SetBool("MovingDown", false);

                }
                else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") > 0)
                {
                    anim_controller.SetBool("MovingLeftRight", false);
                    anim_controller.SetBool("MovingUp", true);
                    anim_controller.SetBool("MovingDown", false);
                }

                else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
                {
                    anim_controller.SetBool("MovingLeftRight", false);
                    anim_controller.SetBool("MovingUp", false);
                    anim_controller.SetBool("MovingDown", false);
            }
                else if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") <0)
                {
                    anim_controller.SetBool("MovingDown", true);
                    anim_controller.SetBool("MovingUp", false);
                    anim_controller.SetBool("MovingLeftRight", false);
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
    
  

    private IEnumerator Dash()
    {
        
        canDash = false;
        dashing = true;
        tr.emitting = true;
        if(input != new Vector3(0,0,0))
        {
            rb.AddForce(input * dashPower);
        }
        else
        {
            rb.AddForce(new Vector2(transform.localScale.x * -1, 0) * dashPower );
        }
        yield return new WaitForSeconds(dashDuration);
        tr.emitting = false;
        dashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    IEnumerator SliderCooldown()
    {
        float counter = 0;

        while (counter < dashCooldown)
        {
            counter += Time.deltaTime;


            float time = dashSlider.value / (dashCooldown - counter) * Time.deltaTime;
            dashSlider.value = Mathf.MoveTowards(dashSlider.value, dashSlider.minValue, time);

            yield return null;
        }
    }
}
