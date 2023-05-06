using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemyarrow : MonoBehaviour
{
    [SerializeField] int damage;
    [HideInInspector] public Skeleton_Attack attack;
    bool coroutineAllowed = true;
    Vector3 target;
    private float CurveTime = 0f;
    Vector3 arrowNextPos;
    private float arrowspeed;
    public Transform attackPoint;
    public Transform controlPoint;
    // Start is called before the first frame update
    void Start()
    {
        target = attack.hitPlayer[0].transform.position;
        if (coroutineAllowed)
        {
            StartCoroutine(ArrowMove());
        }

        CurveTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Destroy(gameObject, 3);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8)
        {
            
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            if(!attack.boosted)
            {
                attack.hitArrows++;
            }
            
        }
        
        Destroy(gameObject);
        

    }

    IEnumerator ArrowMove()
    {
        arrowNextPos = transform.position;

        coroutineAllowed = false;


        while (CurveTime < 1)
        {
            //Movement strzaly
            
           


                if (target.x - attack.gameObject.transform.position.x <= 4.5f && target.x - attack.gameObject.transform.position.x >= -4.5f)
                {
                    arrowspeed = 1.5f;
                    float speedOfArrow = 3f;
                    CurveTime += Time.deltaTime * arrowspeed;
                    transform.position = Vector3.MoveTowards(transform.position, target, speedOfArrow * Time.fixedDeltaTime);
                    Vector3 dir = target - transform.position;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle - 45f, Vector3.forward);

                }
                else
                {
                    CurveTime += Time.deltaTime * arrowspeed;

                    transform.position = Vector3.MoveTowards(transform.position, arrowNextPos, arrowspeed);
                    arrowNextPos = Mathf.Pow(1 - CurveTime, 2) * attackPoint.position + 2 * (1 - CurveTime) * CurveTime * controlPoint.position + Mathf.Pow(CurveTime, 2) * target;

                    //Rotacja strzaly

                    Vector3 dir = arrowNextPos - transform.position;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle - 45f, Vector3.forward);

                    arrowspeed = 1.25f; //default gravity to -9.14

                }

            

            yield return new WaitForEndOfFrame();
        }


        CurveTime = 0f;
        coroutineAllowed = true;
    }
}
