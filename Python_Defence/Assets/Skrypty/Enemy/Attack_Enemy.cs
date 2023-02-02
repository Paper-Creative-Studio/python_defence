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
    private float attackcooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            canAttack= false;
            attackcooldown = Random.Range(minAS, maxAS);
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

            foreach (Collider2D player in hitPlayer)
            {
                Debug.Log("Attacked: " + player);
                player.GetComponent<Health>().TakeDamage(5);
                
            }
            
            StartCoroutine(Cooldown());
        }
        
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackcooldown);
        canAttack = true;
    }
}
