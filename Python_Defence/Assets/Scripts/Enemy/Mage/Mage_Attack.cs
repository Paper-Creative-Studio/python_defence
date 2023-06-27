using System.Collections;
using UnityEngine;

namespace PythonDefence.Enemy
{
    public class Mage_Attack : Attack_Enemy
    {
        private Vector3 target;

        private GameObject spell;
        public GameObject bullet;
        [SerializeField] GameObject Field;
        [SerializeField] GameObject Plama;
        Vector3 playerpos;
        GameObject createdField;
        [SerializeField] int plamaSpawnCount;
        bool canSpecial = true;
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
                        if(canSpecial)
                        {
                            anim.SetTrigger("special");
                            PoleAttack();
                            canSpecial = false;
                            StartCoroutine(SpecialCooldown());
                        }
                        
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
            createdField = Instantiate(Field, playerpos, Quaternion.identity);
            createdField.GetComponent<field>().father = gameObject;
            StartCoroutine(SpawnPlama());
        }
        IEnumerator SpawnPlama()
        {
       
            yield return new WaitForSeconds(1f);
            int spawned = 0;
            do
            {
                Vector2 randSpawnPos = new Vector2(playerpos.x + Random.Range(-2.5f, 2.5f), playerpos.y + Random.Range(-2.5f, 2.5f));
                Instantiate(Plama, randSpawnPos, Quaternion.identity);
                spawned++;
                yield return new WaitForSeconds(0.5f);
            } while (spawned < plamaSpawnCount);
            Destroy(createdField);
        }
        IEnumerator SpecialCooldown()
        {
            yield return new WaitForSeconds(10f);
            canSpecial = true;
        }

    }
}
