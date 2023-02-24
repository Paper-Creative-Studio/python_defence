using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TradeNPC : MonoBehaviour
{
    public GameObject canvas;
    public GameObject hpCanvas;
    private bool talk;
    private GameObject col;
    [SerializeField] private UnityEvent onInteract;
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
                    onInteract.Invoke();
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
    public void StartShop()
    {
        col.GetComponent<Attacking>().canAttack = false;
        col.GetComponent<movement>().moving = false;
        hpCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }
}
