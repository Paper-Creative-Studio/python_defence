using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Attack : MonoBehaviour
{
    private int attackCounter = 0;

    public bool canAttack = true;
    public bool stunned = false;
    public bool isattacking = false;

    private float attackcooldown;
    [SerializeField] private float minAS;
    [SerializeField] private float maxAS;
    [SerializeField] private float attackRange;

    public Collider2D[] hitPlayer;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private LayerMask playerLayer;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
                Debug.Log(attackCounter);
                if (gameObject.name == "Zombie_Object")
                {
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
                else
                {
                    anim.SetTrigger("Attacking");
                }







            }
            StartCoroutine(Cooldown());
        }
    }
}
