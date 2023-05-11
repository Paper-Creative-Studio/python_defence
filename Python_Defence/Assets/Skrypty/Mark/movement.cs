using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float smoothing_speed;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashPower;
    [SerializeField] private float rollPower;
    [SerializeField] private float dashDuration;
    [SerializeField] private float rollDuration;
    

    public Vector3 input;
    private Vector3 smoothmove;
    private Vector3 smoothInputVelocity;

    [HideInInspector] public Rigidbody2D rb;
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
    public bool canRoll = true;

    
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
        if (!health.hitable)
        {
            
            anim_controller.SetBool("MovingLeftRight", false);
            anim_controller.SetBool("MovingUp", false);
            anim_controller.SetBool("MovingDown", false);
        }
        
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
                    if (Input.GetKeyDown(KeyCode.LeftShift) && !dodging && canDash && dashSlider.value < 0.1f)
                    {
                        StartCoroutine(Dash());
                        dashSlider.value = dashSlider.maxValue;
                        StartCoroutine(SliderCooldown());
                    }
                    if (Input.GetKeyDown(KeyCode.Space) && !dodging && canRoll)
                    {
                        canRoll= false;
                        StartCoroutine(Rollin());
                        
                    }
                }
                
            }
            
        }
    }

    private void FixedUpdate()
    {
        
        if (dashing || dodging)
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
        if (!health.hitable || !moving)
        {
            DisableAnimations();
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
                DisableAnimations();
            }
            else if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") <0)
            {
                anim_controller.SetBool("MovingDown", true);
                anim_controller.SetBool("MovingUp", false);
                anim_controller.SetBool("MovingLeftRight", false);
            }
            
        }
    }
    public void DisableAnimations()
    {
        anim_controller.SetBool("MovingLeftRight", false);
        anim_controller.SetBool("MovingUp", false);
        anim_controller.SetBool("MovingDown", false);
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
        if (input.x == 0 && input.y == 1)
        {
            anim_controller.SetTrigger("UpStart");

            canDash = false;
            dashing = true;
            tr.emitting = true;
            if (input != new Vector3(0, 0, 0))
            {
                rb.AddForce(input * dashPower);
            }
            else
            {
                rb.AddForce(new Vector2(transform.localScale.x * -1, 0) * dashPower);
            }
            yield return new WaitForSeconds(dashDuration);
            tr.emitting = false;
            anim_controller.SetTrigger("UpEnd");
            dashing = false;

            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
        }
        else if (input.x == 0 && input.y == -1)
        {
            anim_controller.SetTrigger("DownStart");

            canDash = false;
            dashing = true;
            tr.emitting = true;
            if (input != new Vector3(0, 0, 0))
            {
                rb.AddForce(input * dashPower);
            }
            else
            {
                rb.AddForce(new Vector2(transform.localScale.x * -1, 0) * dashPower);
            }
            yield return new WaitForSeconds(dashDuration);
            tr.emitting = false;
            anim_controller.SetTrigger("DownEnd");
            dashing = false;

            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
        }
        else
        {
            anim_controller.SetTrigger("StartDash");

            canDash = false;
            dashing = true;
            tr.emitting = true;
            if (input != new Vector3(0, 0, 0))
            {
                rb.AddForce(input * dashPower);
            }
            else
            {
                rb.AddForce(new Vector2(transform.localScale.x * -1, 0) * dashPower);
            }
            yield return new WaitForSeconds(dashDuration);
            tr.emitting = false;
            anim_controller.SetTrigger("EndDash");
            dashing = false;

            yield return new WaitForSeconds(dashCooldown);
            canDash = true;
        }

        
    }
    private IEnumerator Rollin()
    {
        if (input.x == 0 && input.y == 1)
        {
            anim_controller.SetTrigger("UpRoll");
        }
        else if (input.x == 0 && input.y == -1)
        {
            anim_controller.SetTrigger("DownRoll");
        }
        else
        {
            anim_controller.SetTrigger("Roll");
        }
            
            dodging = true;
            if (input != new Vector3(0, 0, 0))
            {
                rb.AddForce(input * rollPower);
            }
            else
            {
                rb.AddForce(new Vector2(transform.localScale.x * -1, 0) * rollPower);
            }
            yield return new WaitForSeconds(dashDuration);
        

        
         dodging = false;
         
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
