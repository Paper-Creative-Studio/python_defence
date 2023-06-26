using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Skeleton_Attack : Attack_Enemy
{
    public bool boosted = false;
    

    public int hitArrows = 0;
    
    
    
    [SerializeField] float boostDuration = 5f;

    
    
    
    [SerializeField] GameObject arrow;
    private enemyarrow arrowScript;
    GameObject CA;
    [SerializeField] Transform controlPoint;

    // Update is called once per frame
    
    protected override void Update()
    {
        if (canAttack && !stunned)
        {
            isattacking = true;
            canAttack = false;
            if(!boosted)
            {
                attackcooldown = Random.Range(minAS, maxAS);
            }
            
            hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);


            if (hitPlayer.Length != 0)
            {
                if(hitArrows >2 && !boosted)
                {
                    StartCoroutine(BoostDuration());
                }
                if(boosted)
                {
                    anim.SetTrigger("Boost");
                }
                else
                {
                    anim.SetTrigger("Attacking");
                }
                
            }
            StartCoroutine(Cooldown());
        }
    }
    public override void attack()
    {
        CA = Instantiate(arrow, attackPoint.position, Quaternion.identity);
        arrowScript = CA.GetComponent<enemyarrow>();
        arrowScript.attack = this;
        arrowScript.attackPoint = attackPoint;
        arrowScript.controlPoint = controlPoint;
    }

    
    IEnumerator BoostDuration()
    {
        attackcooldown = 0;
        boosted = true;
        hitArrows = 0;
        yield return new WaitForSeconds(boostDuration);
        boosted = false;
    }
}
