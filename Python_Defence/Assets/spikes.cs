using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class spikes : MonoBehaviour
{
    private Collider2D col;
    public GameObject hitPlayer;
    Rigidbody2D playerRB;
    bool hit;
    [SerializeField] float power;
    float prevY;
    bool letcheck;
    movement moveScript;
    // Start is called before the first frame update
    GameObject ogre;
    Animator playerAnim;
    bool donce = true;
    void Start()
    {
        
        col = GetComponent<Collider2D>();
        
       
    }
   
    private void Update()
    {
        if (hitPlayer != null)
        {
            if (playerRB.velocity.y < 0.5f && playerRB.velocity.y > -0.5f)
                playerAnim.SetTrigger("StayAir");
            if (playerRB.velocity.y < 0f)
                playerAnim.SetTrigger("Falling");
;           if (hitPlayer.transform.position.y <= prevY && letcheck || playerRB.velocity.y == 0)
            {
                playerRB.gravityScale = 0;
                moveScript.moving = true;
                hitPlayer.GetComponent<Casting>().stunned = false;
                moveScript.blockInput = false;
                hitPlayer.GetComponent<Attacking>().stunned = false;
                playerAnim.SetTrigger("EndFall");
                playerAnim.ResetTrigger("KnockedUp");
                playerAnim.ResetTrigger("StayAir");
                if(donce)
                {
                    donce = false;
                    StartCoroutine(ResetEnd());
                }
                    
                playerAnim.ResetTrigger("Falling");
                hit = false;
            }
        }
            
    }
    IEnumerator ResetEnd()
    {
        yield return new WaitForSeconds(0.01f);
        
    }
    public void Destroy()
    {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider2D>());

        Destroy(gameObject, 2f);

    }
    public void UnsetTrigger()
    {
        col.isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hit && collision.gameObject.layer == 8)
        {
            hitPlayer = GameObject.FindGameObjectWithTag("Player");
            Physics2D.IgnoreCollision(collision, col);
            playerRB = hitPlayer.GetComponent<Rigidbody2D>();
            moveScript = hitPlayer.GetComponent<movement>();
            playerAnim = hitPlayer.GetComponent<Animator>();
            Debug.Log("trafiony");
            hit = true;
            prevY = hitPlayer.transform.position.y;
            playerRB.velocity = Vector2.zero;
            moveScript.moving = false;
            hitPlayer.GetComponent<Casting>().stunned= true;
            moveScript.blockInput = true;
            moveScript.DisableAnimations();
            hitPlayer.GetComponent<Attacking>().stunned= true;
            playerRB.gravityScale = 1;
            playerRB.AddForce(Vector2.up * power, ForceMode2D.Impulse);
            playerAnim.SetTrigger("KnockedUp");
            StartCoroutine(LetCheck());
            
        }
    }
    IEnumerator LetCheck()
    {
        yield return new WaitForSeconds(0.5f);
        letcheck= true;
    }
   

}
