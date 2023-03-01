using Microsoft.Scripting.Utils;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    public GameObject arrow;
    public GameObject bullet;
    public float speed;
    private GameObject spell;
    private GameObject createdArrow;
    public Vector3 target;
    private float CurveTime = 0f;
    private bool coroutineAllowed = true;
    private Vector3 arrowNextPos;
    public Transform controlPoint;
    private Vector3 gizmosPosition;
    public bool printuj = false;
    private float arrowspeed;
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
        target = hitPlayer[0].transform.position;
        spell.GetComponent<spell>().target= target;
        
       
        
    }
    public void shootArrow()
    {

        createdArrow = (GameObject)Instantiate(arrow, attackPoint.position, Quaternion.identity);
        target = hitPlayer[0].transform.position;
        if (coroutineAllowed)
        {
            StartCoroutine(ArrowMove());
        }
        CurveTime = 0f;


    }
    IEnumerator ArrowMove()
    {
        arrowNextPos = createdArrow.transform.position;

        coroutineAllowed = false;


        while (CurveTime < 1)
        {
            
            //Movement strzaly
            if (createdArrow != null)
            {

                
                if ( target.x - transform.position.x <= 4.5f && target.x - transform.position.x >= -4.5f)
                {
                    arrowspeed = 1.5f;
                    float speedOfArrow = 5f;
                    CurveTime += Time.deltaTime * arrowspeed;
                    createdArrow.transform.position = Vector3.MoveTowards(createdArrow.transform.position, target, speedOfArrow * Time.fixedDeltaTime);
                    Vector3 dir = target - createdArrow.transform.position;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    createdArrow.transform.rotation = Quaternion.AngleAxis(angle - 45f, Vector3.forward);
                    
                }
                else
                {
                    CurveTime += Time.deltaTime * arrowspeed;

                    createdArrow.transform.position = Vector3.MoveTowards(createdArrow.transform.position, arrowNextPos, arrowspeed);
                    arrowNextPos = Mathf.Pow(1 - CurveTime, 2) * attackPoint.position + 2 * (1 - CurveTime) * CurveTime * controlPoint.position + Mathf.Pow(CurveTime, 2) * target;

                    //Rotacja strzaly

                    Vector3 dir = arrowNextPos - createdArrow.transform.position;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    createdArrow.transform.rotation = Quaternion.AngleAxis(angle - 45f, Vector3.forward);
                   
                    arrowspeed = 1.25f; //default gravity to -9.14
                    
                }
                
            }

            yield return new WaitForEndOfFrame();
        }

        
        CurveTime = 0f;
        coroutineAllowed = true;
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
    private void OnDrawGizmos()
    {
        //if(printuj)
        //{
        //    for (float t = 0; t <= 1; t += 0.05f)
        //    {
        //        gizmosPosition = Mathf.Pow(1 - t, 2) * attackPoint.position + 2 * (1 - t) * t * controlPoint.position + Mathf.Pow(t, 2) * target;

        //        Gizmos.DrawSphere(gizmosPosition, 0.25f);
        //    }
        //    Gizmos.DrawLine(new Vector3(attackPoint.position.x, attackPoint.position.y, attackPoint.position.z), new Vector3(controlPoint.position.x, controlPoint.position.y, controlPoint.position.z));

        //    Gizmos.DrawLine(new Vector3(controlPoint.position.x, controlPoint.position.y, controlPoint.position.z), new Vector3(target.x, target.y, target.z));
        //}
    }
        

}
