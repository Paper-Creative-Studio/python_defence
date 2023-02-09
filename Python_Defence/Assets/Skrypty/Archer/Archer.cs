using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    private GameObject createdArrow;

    private Transform target;
    public Transform shootPoint;
    public Transform controlPoint;

    private Vector2 gizmosPosition;

    private Vector3 arrowNextPos;
    private Vector3 enemy;

    public Animator anim_controller;

    public float attackRange;
    private float CurveTime = 0f;
    private float arrowSpeed = 0.5f;
    public float angle;

    private bool coroutineAllowed = true;
    private bool canAttack = true;

    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            if(target != null)
            {
                canAttack = false;
                anim_controller.SetTrigger("Shoot");
                StartCoroutine(Cooldown());
            }
                
        }
        StartCoroutine(FOVCheck());

    }
    public void shootArrow()
    {
        
            createdArrow = (GameObject)Instantiate(arrow, shootPoint.position, Quaternion.identity);
            enemy = target.position;
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
            
            CurveTime += Time.deltaTime * arrowSpeed;
            
            createdArrow.transform.position = Vector3.MoveTowards(createdArrow.transform.position, arrowNextPos, arrowSpeed);
            arrowNextPos = Mathf.Pow(1 - CurveTime, 2) * shootPoint.position + 2 * (1 - CurveTime) * CurveTime * controlPoint.position + Mathf.Pow(CurveTime, 2) * enemy;
            
            //Rotacja strzaly

            Vector3 dir = arrowNextPos - createdArrow.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            createdArrow.transform.rotation = Quaternion.AngleAxis(angle - 45f, Vector3.forward);
            if (createdArrow.transform.position.y - arrowNextPos.y <= 0)
            {
                arrowSpeed = 0.5f; 
            }
            else
            {

                arrowSpeed -= -0.87f * Time.deltaTime; //default gravity to -9.14
            }
            yield return new WaitForEndOfFrame();
        }
        CurveTime = 0f;
        coroutineAllowed = true;
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(5);
        canAttack = true;
    }
    IEnumerator FOVCheck()
    {
        yield return new WaitForSeconds(0.2f);
        Collider2D foundEnemy = Physics2D.OverlapCircle(transform.position + new Vector3(-6f, 0, 0), attackRange, enemyLayer);
        Debug.Log(foundEnemy);
        if (foundEnemy != null)
        {
            if (foundEnemy.transform.position.x < transform.position.x)
            {
                target = foundEnemy.transform;
            }

        }
        else
        {
            target =null;
        }


    }

    //private void OnDrawGizmos()
    //{
    //    for (float t = 0; t <= 1; t += 0.05f)
    //    {
    //        gizmosPosition = Mathf.Pow(1 - t, 2) * shootPoint.position + 2 * (1 - t) * t * controlPoint.position + Mathf.Pow(t, 2) * target.position;

    //        Gizmos.DrawSphere(gizmosPosition, 0.25f);
    //    }
    //    Gizmos.DrawLine(new Vector3(shootPoint.position.x, shootPoint.position.y, shootPoint.position.z), new Vector3(controlPoint.position.x, controlPoint.position.y, controlPoint.position.z));
    //    Gizmos.DrawLine(new Vector3(controlPoint.position.x, controlPoint.position.y, controlPoint.position.z), new Vector3(target.position.x, target.position.y, target.position.z));
    //}
}
