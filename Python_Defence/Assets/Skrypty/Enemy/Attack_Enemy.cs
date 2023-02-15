using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack_Enemy : MonoBehaviour
{
    private bool canAttack = true;
    [SerializeField] private float minAS;
    [SerializeField] private float maxAS;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int damage;
    private float attackcooldown;
    public Animator anim;
    public bool triggered = false;
    private Collider2D[] hitPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (canAttack)
            {
                canAttack = false;
                attackcooldown = Random.Range(minAS, maxAS);
                hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
                Debug.Log(hitPlayer);
                if(hitPlayer != null)
                {
                    anim.SetTrigger("Attacking");
                }
                
                


                StartCoroutine(Cooldown());
            }
        
        
        
    }
    public void attack()
    {
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Health>().TakeDamage(damage);
        }
    }
        
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackcooldown);
        canAttack = true;
    }
    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawSphere(attackPoint.position, attackRange);
    //}

}
