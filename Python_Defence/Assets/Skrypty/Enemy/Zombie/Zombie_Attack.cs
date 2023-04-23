using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Attack : Attack_Enemy
{
    private int attackCounter = 0;
    //[SerializeField] private int damage;

    //public bool canAttack = true;
    //public bool stunned = false;
    //public bool isattacking = false;

    //private float attackcooldown;
    //[SerializeField] private float minAS;
    //[SerializeField] private float maxAS;
    //[SerializeField] private float attackRange;


    //private Collider2D[] hitPlayer;

    //[SerializeField] private Transform attackPoint;

    //[SerializeField] private LayerMask playerLayer;

    //private Animator anim;
    // Start is called before the first frame update

   
    // Update is called once per frame
    protected override void Update()
    {
        if (canAttack && !stunned)
        {
            isattacking = true;
            canAttack = false;
            attackcooldown = Random.Range(minAS, maxAS);
            hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

            if (hitPlayer.Length != 0)
            {
                attackCounter++;
                if (attackCounter > 2)
                {
                    attackCounter = 0;
                    anim.SetTrigger("DoubleSlash");
                }
                else
                {
                    anim.SetTrigger("Attacking");
                }
            }
            StartCoroutine(Cooldown());
        }
    }
}
