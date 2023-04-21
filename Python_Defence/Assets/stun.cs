using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stun : MonoBehaviour
{
    public bool stunned = false;
    public AIDestinationSetter AI;
    // Start is called before the first frame update
    void Start()
    {
       AI = gameObject.GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stunned)
        {
            StartCoroutine(StopStun());
            stunned= false;
        }
    }
    IEnumerator StopStun()
    {
        Debug.Log("gowno");
        yield return new WaitForSeconds(3f);
        AI.ai.canMove = true;
        AI.canChange = true;
        transform.GetChild(0).GetComponent<Attack_Enemy>().stunned = false;

    }
}
