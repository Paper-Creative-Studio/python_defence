using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Archer : MonoBehaviour
{
    public GameObject arrow;

    public Transform target;
    public Transform shootPoint;

    private bool canAttack = true;

    public Animator anim_controller;
    
    public LayerMask enemyLayers;
    [Range(0, 360)]
    public float FOVAngle;
    
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            StartCoroutine(FindTarget());
            canAttack = false;
            anim_controller.SetTrigger("Shoot");
            StartCoroutine(Cooldown());
           
        }
        
    }
    public void shootArrow()
    {
        Instantiate(arrow, shootPoint.position, Quaternion.identity);
       
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(5);
        canAttack = true;
    }
    IEnumerator FindTarget()
    {
        yield return new WaitForSeconds(0.2f);
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);
        if (hitEnemy.Length != 0)
        {
            target = hitEnemy[0].transform;
            Vector2 directionToTarget = target.position - transform.position;
            if (Vector2.Angle(transform.forward, directionToTarget) < FOVAngle / 2)
            {
                Debug.Log("Target: " + target);
            }
        }
    }
}
