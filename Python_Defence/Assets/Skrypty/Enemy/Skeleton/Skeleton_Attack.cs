using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Skeleton_Attack : MonoBehaviour
{
    public bool canAttack = true;
    public bool stunned = false;
    public bool isattacking = false;
    bool coroutineAllowed = true;

    float attackcooldown;
    [SerializeField] float minAS;
    [SerializeField] float maxAS;
    [SerializeField] float attackRange;
    private float CurveTime = 0f;
    private float arrowspeed;

    Vector3 target;
    Vector3 arrowNextPos;

    GameObject createdArrow;
    [SerializeField] GameObject arrow;

    [SerializeField] Transform attackPoint;
    [SerializeField] Transform controlPoint;

    private Collider2D[] hitPlayer;

    Animator anim;

    [SerializeField] LayerMask playerLayer;
    void Start()
    {
        anim= GetComponent<Animator>();
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
                anim.SetTrigger("Attacking");
            }
            StartCoroutine(Cooldown());
        }
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

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackcooldown);
        canAttack = true;
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


                if (target.x - transform.position.x <= 4.5f && target.x - transform.position.x >= -4.5f)
                {
                    arrowspeed = 1.5f;
                    float speedOfArrow = 3f;
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
}
