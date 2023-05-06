using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class spikes : MonoBehaviour
{
    private Collider2D col;
    GameObject hitPlayer;
    Rigidbody2D playerRB;
    bool hit;
    [SerializeField] float power;
    float prevY;
    bool letcheck;
    movement moveScript;
    // Start is called before the first frame update
    
    void Start()
    {
        
        col = GetComponent<Collider2D>();
        
       
    }
    private void Update()
    {
        if (hitPlayer != null)
            if (hitPlayer.transform.position.y <= prevY && letcheck)
            {
                playerRB.gravityScale = 0;
                hitPlayer.GetComponent<movement>().moving = true;
            
            }
    }
    public void Destroy()
    {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider2D>());

        Destroy(gameObject, 3f);

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
            Debug.Log("trafiony");
            hit = true;
            prevY = hitPlayer.transform.position.y;
            playerRB.velocity = Vector2.zero;
            moveScript.moving = false;
            
            playerRB.gravityScale = 1;
            playerRB.AddForce(Vector2.up * power, ForceMode2D.Impulse);
            
            StartCoroutine(LetCheck());
            
        }
    }
    IEnumerator LetCheck()
    {
        yield return new WaitForSeconds(0.5f);
        letcheck= true;
    }
   

}
