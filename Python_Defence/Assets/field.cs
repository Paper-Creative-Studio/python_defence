using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class field : MonoBehaviour
{
    public GameObject father;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(father==null)
            Destroy(gameObject);
    }
}
