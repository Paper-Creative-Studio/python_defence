using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmamanagement : MonoBehaviour
{
    public Sprite zasiane;
    public Sprite wyrosniete;
    public Sprite puste;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void zasiej()
    {
        for(int i =0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = zasiane;
            
        }
            
    }
    public void Wyrosnij()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = wyrosniete;
        }
    }
    public void Zbierz()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = puste;
        }
    }
}
