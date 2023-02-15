using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sprite : MonoBehaviour
{
    public AIPath aipath;
    public bool print = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(print)
        {
            
            Debug.Log(aipath.desiredVelocity.x);
        }
        

        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
