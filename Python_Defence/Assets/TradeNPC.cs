using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeNPC : MonoBehaviour
{
    public GameObject canvas;
    public GameObject hpCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.GetComponent<Attacking>().canAttack = false;
                collision.gameObject.GetComponent<movement>().canMove = false;
                hpCanvas.gameObject.SetActive(false);
                canvas.gameObject.SetActive(true);
            }
        }
        
        
    }
}
