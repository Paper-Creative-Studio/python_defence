using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeNPC : MonoBehaviour
{
    public GameObject canvas;
    public GameObject hpCanvas;
    private bool talk;
    private GameObject col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (talk)
                { 
                    col.GetComponent<Attacking>().canAttack = false;
                    col.GetComponent<movement>().moving = false;
                    hpCanvas.gameObject.SetActive(false);
                    canvas.gameObject.SetActive(true);
                }
            }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        
            
            if (collision.CompareTag("Player"))
            {
                col = collision.gameObject;
                talk= true;
            }
        
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            col = null;
            talk = false;
        }
    }
}
