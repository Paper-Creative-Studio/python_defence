using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private float aoeRange;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask enemyLayers;
    private List<GameObject> hitEnemies= new List<GameObject>();
    public Sprite stunSprite;
    private Transform lastTarget;
    private Transform lastSecondaryTarget;
   
    void DoDamage()
    {
        Collider2D[] explosion = Physics2D.OverlapCircleAll(transform.position, aoeRange, enemyLayers);


        foreach (Collider2D enemy in explosion)
        {
             
            hitEnemies.Add(enemy.gameObject);
            enemy.GetComponent<Enemy_Health>().TakeDamage(damage);
            AIDestinationSetter enemyAI = enemy.transform.parent.gameObject.GetComponent<AIDestinationSetter>();
            enemyAI.ai.canMove = false;
            //lastTarget = enemyAI.target;
            //lastSecondaryTarget = enemyAI.SecondaryTarget;
            //enemyAI.target = null;
            //enemyAI.SecondaryTarget = null;
            enemy.GetComponent<Attack_Enemy>().stunned = true;
            enemyAI.canChange = false;
            enemy.transform.parent.gameObject.GetComponent<stun>().stunned= true;
        }
        
    }
    void Disappear()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        
            Gizmos.DrawSphere(transform.position, aoeRange);
        

    }
}
