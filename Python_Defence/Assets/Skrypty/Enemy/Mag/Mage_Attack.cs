using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Mage_Attack : MonoBehaviour
{
    [SerializeField] private int damage;

    public bool canAttack = true;
    public bool stunned = false;
    public bool isattacking = false;

    private float attackcooldown;
    [SerializeField] private float minAS;
    [SerializeField] private float maxAS;
    [SerializeField] private float attackRange;

    private Vector3 target;

    private Collider2D[] hitPlayer;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private LayerMask playerLayer;

    private Animator anim;

    private GameObject spell;
    public GameObject bullet;

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
                anim.SetTrigger("Attacking");
            }
            StartCoroutine(Cooldown());
        }
    }

    public void MageAttack()
    {
        spell = (GameObject)Instantiate(bullet, attackPoint.position, Quaternion.identity);
        target = hitPlayer[0].transform.position;
        spell.GetComponent<spell>().target = target;
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackcooldown);
        canAttack = true;
    }
}
