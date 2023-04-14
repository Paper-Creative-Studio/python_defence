using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DynamicMovementTest : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Y) && canDash)
        {
            StartCoroutine(DynamicDash());
            
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(KinematicDash());
        }
    }
    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
    }
    IEnumerator DynamicDash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash= true;
        
    }
    IEnumerator KinematicDash()
    {
        canDash = false;
        rb.MovePosition(transform.position + new Vector3(5f, 0f));
        yield return new WaitForSeconds(2f);
        canDash = true;
    }
}
