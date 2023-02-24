using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Animator anim_controller;
    public int damage;
    public bool canAttack = true;
    private Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
       if(health.alive)
        {
            if (Input.GetButtonDown("Fire1") && canAttack)
            {

                canAttack = false;
                anim_controller.SetTrigger("Attacking");

                StartCoroutine(Cooldown());

            }
        }
        
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Health>().TakeDamage(damage);
        }
        
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawSphere(attackPoint.position, attackRange);
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //    collision.gameObject.GetComponent<AIDestinationSetter>().move = false;
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
        
    //    collision.gameObject.GetComponent<AIDestinationSetter>().move = true;
    //}
}
