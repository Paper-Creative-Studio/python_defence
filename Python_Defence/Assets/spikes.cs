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
        hitPlayer = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(hitPlayer.GetComponent<Collider2D>(), col);
    }
    private void Update()
    {
        if (prevY != 0 && letcheck)
            Debug.Log(hitPlayer.transform.position.y + " " + prevY);
        if (hitPlayer.transform.position.y == prevY && letcheck)
        {
            playerRB.gravityScale = 0;
            hitPlayer.GetComponent<movement>().moving = true;
            
        }
    }
    public void Destroy()
    {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider2D>());

        //Destroy(gameObject, 3f);

    }
    public void UnsetTrigger()
    {
        col.isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hit)
        {
            Physics2D.IgnoreCollision(collision, col);
            playerRB = hitPlayer.GetComponent<Rigidbody2D>();
            moveScript = hitPlayer.GetComponent<movement>();
            Debug.Log("trafiony");
            hit = true;
            prevY = hitPlayer.transform.position.y;
            moveScript.input = Vector3.zero;
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
