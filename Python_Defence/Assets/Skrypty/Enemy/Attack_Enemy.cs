using Microsoft.Scripting.Utils;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Attack_Enemy : MonoBehaviour
{
    [SerializeField] private int damage;

    public bool isattacking = false;
    public bool canAttack = true;
    public bool stunned = false;

    [SerializeField] private float minAS;
    [SerializeField] private float maxAS;
    [SerializeField] private float attackRange;
    private float attackcooldown;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;
    private Collider2D[] hitPlayer;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        if (canAttack && !stunned)
        {
            isattacking= true;
            canAttack = false;
            attackcooldown = Random.Range(minAS, maxAS);
            hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);


            if (hitPlayer.Length != 0)
            {
                anim.SetTrigger("Attacking");
            }
            StartCoroutine(Cooldown());
        }
    }
    
    protected void attack()
    {
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Health>().TakeDamage(damage);
        }
    }

    protected IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackcooldown);
        canAttack = true;
    }
        

}
