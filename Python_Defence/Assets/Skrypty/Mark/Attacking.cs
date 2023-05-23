using Microsoft.Scripting;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Attacking : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Animator anim_controller;
    [SerializeField] private AudioClip woosh_sound;
    [SerializeField] private AudioSource source;
    public int damage;
    public bool canAttack = true;
    private Health health;
    private Queue<string> animationQueue = new Queue<string>();
    private string currentAttack = "";
    bool resetattack = false;
    int changes = 0;
    Coroutine currentTimer;
    Coroutine moveTimer;
    movement movement;
    [HideInInspector] public bool stunned = false;
    Condition condition;
    // Start is called before the first frame update
    void Start()
    {
        LoadAttacks();
        source = GetComponent<AudioSource>();  
        health = GetComponent<Health>();
        movement = GetComponent<movement>();
       condition= GetComponent<Condition>();
    }

    // Update is called once per frame
    void Update()
    {
       if(health.alive)
       {
            if (Input.GetButtonDown("Fire1") && canAttack && condition.Check())
            {
                movement.attacking= true;
                if(resetattack)
                {
                    if(animationQueue.Count != 0)
                    {
                        for (int i = 0; i <= animationQueue.Count; i++) //wywal wszystko z queue
                        {
                            animationQueue.Dequeue();
                        }
                    }
                    
                    LoadAttacks();


                    resetattack = false;
                }
                if(animationQueue.Count == 0)
                {
                    LoadAttacks();
                }
                currentAttack = animationQueue.Dequeue();
                changes++;
                AttackMove();
                anim_controller.SetTrigger(currentAttack);

                if(currentTimer!=null)
                    StopCoroutine(currentTimer);
                currentTimer = StartCoroutine(ChangeTimer());
                canAttack = false;
                StartCoroutine(Cooldown());

            }
        }
        
    }
    public void EndAttack()
    {
        movement.attacking = false;
    }
    public void LoadAttacks()
    {
        animationQueue.Enqueue("atak1");
        animationQueue.Enqueue("atak2");
        animationQueue.Enqueue("atak3");
    }
    public void AttackMove()
    {
        movement.blockInput = true;
        movement.input = Vector3.left * transform.localScale.x;
        if (moveTimer != null)
            StopCoroutine(moveTimer);
        moveTimer = StartCoroutine(Moveattack());
    }
    public void Attack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Health>().TakeDamage(damage);
        }
        
    }
    public void PlaySound()
    {
        source.PlayOneShot(woosh_sound);
    }
    IEnumerator Moveattack()
    {
        yield return new WaitForSeconds(0.25f);
        movement.input = Vector3.zero;
        movement.blockInput = false;
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    IEnumerator ChangeTimer()
    {
        yield return new WaitForSeconds(3f);
            resetattack = true;
    }
}
