using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    [SerializeField]private Transform endPoint;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform Player;
    private float dist;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    bool havepath = false;
    Path path;
    [SerializeField] private float viewRange;
    public Seeker seeker;
    Rigidbody2D rb;
    [SerializeField] private float nextWaypointDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        dist = Vector3.Distance(Player.position, transform.position);
        if(dist <= viewRange)
        {
            seeker.StartPath(rb.position, Player.position, OnPathComplete);
        }
       
    }
    private void FixedUpdate()
    {
        if (dist > viewRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            
        }
        
    }
    void OnPathComplete(Path p)
    { 
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
            
        }
    }
    

}