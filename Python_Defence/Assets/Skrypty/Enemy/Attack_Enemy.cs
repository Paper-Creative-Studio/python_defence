using Microsoft.Scripting.Utils;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack_Enemy : MonoBehaviour
{
    public bool isattacking = false;
    private bool canAttack = true;
    [SerializeField] private float minAS;
    [SerializeField] private float maxAS;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int damage;
    private float attackcooldown;
    public Animator anim;
   
    public Collider2D[] hitPlayer;
    
    public GameObject bullet;
    public float speed;
    private GameObject spell;
    
    public Vector3 spelltarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canAttack)
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
    
    public void attack()
    {
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Health>().TakeDamage(damage);
        }
    }
    public void MageAttack()
    {
        spell = (GameObject)Instantiate(bullet, attackPoint.position, Quaternion.identity);
        spelltarget = hitPlayer[0].transform.position;
        spell.GetComponent<spell>().target= spelltarget;
        
       
        
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
