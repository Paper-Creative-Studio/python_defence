using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private float aoeRange;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask enemyLayers;
    private List<GameObject> hitEnemies= new List<GameObject>();
    public Sprite stunSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in hitEnemies)
        {
            Debug.Log(enemy.transform.parent.gameObject.GetComponent<AIDestinationSetter>().ai.canMove);
            Debug.Log(enemy.GetComponent<Attack_Enemy>().canAttack);
        }
    }
    void DoDamage()
    {
        Collider2D[] explosion = Physics2D.OverlapCircleAll(transform.position, aoeRange, enemyLayers);


        foreach (Collider2D enemy in explosion)
        {
            hitEnemies.Add(enemy.gameObject);
            enemy.GetComponent<Enemy_Health>().TakeDamage(damage);

            enemy.transform.parent.gameObject.GetComponent<AIDestinationSetter>().ai.canMove = false;
            enemy.GetComponent<Attack_Enemy>().canAttack = false;
            enemy.gameObject.GetComponent<SpriteRenderer>().sprite = stunSprite;
            StartCoroutine(StopStun());
            
           

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
    IEnumerator StopStun()
    {
        yield return new WaitForSeconds(3);
        foreach (var enemy in hitEnemies)
        {
            enemy.GetComponent<AIDestinationSetter>().ai.canMove = true;
            enemy.transform.GetChild(0).GetComponent<Attack_Enemy>().canAttack = true;
        }
        
        
    }
}
