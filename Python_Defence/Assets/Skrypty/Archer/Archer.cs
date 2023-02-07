using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
   
    
    public float attackRange;

    private Vector2 gizmosPosition;

    public Transform controlPoint;

    
    private float CurveTime = 0f;

    private float arrowSpeed = 0.5f;
    private bool coroutineAllowed = true;
    private GameObject createdArrow;
    private Vector3 arrowPos;
    private float arrowY2;
    Vector2 diff;
    bool asad;
    Vector3 enemy;
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
            anim_controller.SetTrigger("Shoot");
            StartCoroutine(Cooldown());
           
        }

        Debug.Log(createdArrow.transform.rotation);
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
        
        coroutineAllowed = false;
        while (CurveTime < 1)
        {
            //Movement strzaly
            arrowPos = createdArrow.transform.position;
            CurveTime += Time.deltaTime * arrowSpeed;
            createdArrow.transform.position = Mathf.Pow(1 - CurveTime, 2) * transform.position + 2 * (1 - CurveTime) * CurveTime * controlPoint.position + Mathf.Pow(CurveTime, 2) * enemy;
            
            if (createdArrow.transform.position.y - arrowPos.y >= 0)
            {
                arrowSpeed = 0.5f;
            }
            else
            {
                
                arrowSpeed -= -0.80f * Time.deltaTime; //default gravity to -9.14
            }

            //Rotacja strzaly
            diff = arrowPos - createdArrow.transform.position;
            createdArrow.transform.eulerAngles = new Vector3(69,69,69);

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

    private void OnDrawGizmos()
    {
        for(float t =0;t<=1;t+=0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 2) * transform.position + 2 * (1 - t)  * t * controlPoint.position + Mathf.Pow(t,2) * target.position;

            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(controlPoint.position.x, controlPoint.position.y, controlPoint.position.z));
        Gizmos.DrawLine(new Vector3(controlPoint.position.x, controlPoint.position.y, controlPoint.position.z), new Vector3(target.position.x, target.position.y, target.position.z));
    }
}
