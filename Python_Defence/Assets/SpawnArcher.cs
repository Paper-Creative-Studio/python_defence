using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArcher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftarcher;
    public GameObject downarcher;
    public List<Transform> leftSpawnpoint = new List<Transform>();
    public List<Transform> downSpawnpoint = new List<Transform>();
    private bool left = true;
    public GameObject arrow;
    public arrow arscript;
    private void Start()
    {
        arscript = arrow.GetComponent<arrow>();
    }
    
    public void SpawnArch()
    {
        
        if (left)
        {
            if(leftSpawnpoint.Count != 0)
            {
                Instantiate(leftarcher, leftSpawnpoint[0].position, Quaternion.identity);
                leftSpawnpoint.RemoveAt(0);
                left = false;
            }
            else
            {
                arscript.damage += 10;
            }
            
        }
        else
        {
            if(downSpawnpoint.Count != 0)
            {
                Instantiate(downarcher, downSpawnpoint[0].position, Quaternion.identity);
                downSpawnpoint.RemoveAt(0);
                left = true;
            }
            else
            {
                arscript.damage += 10;
            }
            
        }
        
    }

}
