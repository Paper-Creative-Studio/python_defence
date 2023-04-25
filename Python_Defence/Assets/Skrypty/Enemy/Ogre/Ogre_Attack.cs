using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ogre_Attack : Attack_Enemy
{
    private int rng;
    private float dist;
    private Transform player;
    private AIDestinationSetter ogreAI;
    [SerializeField] GameObject spike;
    Vector3 spawnPos;
    float neededSpikes;
    float distanceToPlayer;
    float lerpedValue = 0;
    Vector3 target;
    private new void Start()
    {
        base.Start();
        ogreAI = transform.parent.GetComponent<AIDestinationSetter>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    protected override void Update()
    {
        
       
        
        if (canAttack && !stunned)
        {
            //Creates circle that is enemy attack range and it determines if there is target or not
            isattacking = true;
            canAttack = false;
            attackcooldown = Random.Range(minAS, maxAS);
            hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
            dist = Vector3.Distance(transform.position, player.position);
            if (hitPlayer.Length != 0)
            {
                
                anim.SetTrigger("Attacking");
            }
            else if(dist > attackRange && ogreAI.ai.destination == player.position)
            {
                rng = Random.Range(1,3);
               
                if (rng == 2)
                {
                    Shockwave();
                    
                }
            }
            StartCoroutine(Cooldown());
        }
    }
    void Shockwave()
    {
        ogreAI.ai.canMove = false;
        ogreAI.canChange = false;
        anim.SetTrigger("Shockwave");
    } 
    public void EnableMove()
    {
        ogreAI.ai.canMove = true;
        ogreAI.canChange = true;
    }
    public void SpawnSpikes()
    {
        neededSpikes = Mathf.RoundToInt(Vector3.Distance(transform.position, player.position));
        distanceToPlayer = 1 / neededSpikes;
        lerpedValue = 0;
        target = player.position;
        StartCoroutine(SpikeWave());
        
        
    }
    IEnumerator SpikeWave()
    {
        for (int i = 0; i < neededSpikes; i++)
        {
            lerpedValue += distanceToPlayer;
            spawnPos = Vector3.Lerp(transform.position, target, lerpedValue);
            Instantiate(spike, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
