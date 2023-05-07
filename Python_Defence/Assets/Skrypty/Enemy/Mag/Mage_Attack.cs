
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static IronPython.Modules.PythonIterTools;
using static UnityEngine.GraphicsBuffer;

public class Mage_Attack : Attack_Enemy
{
    private Vector3 target;

    private GameObject spell;
    public GameObject bullet;
    [SerializeField] GameObject Field;
    [SerializeField] GameObject Plama;
    Vector3 playerpos;
    [SerializeField] int plamaSpawnCount;
    // Update is called once per frame
    protected override void Update()
    {
        if (canAttack && !stunned)
        {
            isattacking = true;
            canAttack = false;
            attackcooldown = Random.Range(minAS, maxAS);
            hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

            int specAtChance = Random.Range(1,5);
            if (hitPlayer.Length != 0)
            {
                if (specAtChance != 4)
                    anim.SetTrigger("Attacking");
                else
                {
                    anim.SetTrigger("Pole");
                    PoleAttack();
                }
                    
            }
            StartCoroutine(Cooldown());
        }
    }

    public override void attack()
    {
        spell = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        target = hitPlayer[0].transform.position;
        spell.GetComponent<spell>().target = target;
    }
    void PoleAttack()
    {
        playerpos = hitPlayer[0].transform.position;
        Instantiate(Field, playerpos, Quaternion.identity);
        
        StartCoroutine(SpawnPlama());
    }
    IEnumerator SpawnPlama()
    {
       
        yield return new WaitForSeconds(1);
        int spawned = 0;
        do
        {
            Vector2 randSpawnPos = new Vector2(playerpos.x + Random.Range(-3, 3), playerpos.y + Random.Range(-3, 3));
            Instantiate(Plama, randSpawnPos, Quaternion.identity);
            spawned++;
            yield return new WaitForSeconds(1);
        } while (spawned < plamaSpawnCount);
        Destroy(Field);
        
    }

}
