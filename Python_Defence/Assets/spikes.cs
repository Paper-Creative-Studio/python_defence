using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col= GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void UnsetTrigger()
    {
        col.isTrigger = false;
    }
}
