using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Casting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera cam;
    [SerializeField] private Transform castPoint;
    [SerializeField] private LayerMask enemyLayers;
    private movement moveScript;
    private Animator anim;
    private Health health;
     
    private bool startMovement = false;
    Vector3 mousepos;


    [Header("Fireball")]
    public bool fb_unlocked = false;
    [SerializeField] private int fb_damage = 10;
    [SerializeField] private int fb_burnDamage = 3;
    [SerializeField] private GameObject fireball;
    [SerializeField] private float fb_speed;
    [SerializeField] private float fb_aoeRange;
    private bool fb_canCast = true;
    private GameObject fb_object;
    float fb_cooldown = 5f;
    [SerializeField] private Slider fb_slider;
    [SerializeField] private GameObject explosion_VFX;
    [SerializeField] private GameObject enemy_burn_vfx;
    private int burnTicks = 5;
    private List<GameObject> fb_hitEnemies = new List<GameObject>();
    

    [Header("Lightning")]
    public bool lt_unlocked = false;
    [SerializeField] private GameObject lightning;
    private bool lt_canCast = true;
    public float lt_cooldown = 5f;
    private GameObject lt_object;
    [SerializeField] private Slider lt_slider;
    float dist;
    public bool stunned = false;
    public bool casting = false;
    Condition condition;
    void Start()
    {
        health= GetComponent<Health>();
        anim = GetComponent<Animator>();
        moveScript = GetComponent<movement>();
        condition= GetComponent<Condition>();
    }
    // Update is called once per frame
    void Update()
    {
        if (fb_slider.value < 0.1f)
            fb_canCast= true;
        if(lt_slider.value < 0.1f)
            lt_canCast = true;
        if (fb_unlocked && Input.GetKeyDown(KeyCode.Z) && fb_canCast && fb_slider.value < 0.1f && !stunned && Time.timeScale == 1 && condition.Check())
        {
            moveScript.DisableAnimations();
            moveScript.moving= false;
            casting = true;

            fb_canCast = false;
            
            anim.SetTrigger("CastFireball");
            
        }
        else if (lt_unlocked && Input.GetKeyDown(KeyCode.X) && lt_canCast && lt_slider.value < 0.1f & !stunned && Time.timeScale == 1 && condition.Check())
        {
            moveScript.DisableAnimations();
            moveScript.moving = false;
            casting = true;
            lt_canCast = false;
            
            anim.SetTrigger("CastLightning");
        }

        if(fb_object != null)
        {
             dist = mousepos.x - castPoint.position.x;
            if (dist > 0)
            {
                Vector3 fb_scale = fb_object.transform.localScale;
                fb_scale.x = -3;
                fb_object.transform.localScale = fb_scale;
            }
            else
            {
                Vector3 fb_scale = fb_object.transform.localScale;
                fb_scale.x = 3;
                fb_object.transform.localScale = fb_scale;
            }
            if (startMovement)
            {
                
                fb_object.transform.position = Vector3.MoveTowards(fb_object.transform.position, mousepos, fb_speed * Time.deltaTime);
               
                if (fb_object.transform.position == mousepos)
                {
                    GameObject explosion_obj = Instantiate(explosion_VFX, fb_object.transform.position,Quaternion.identity);
                    Collider2D[] explosion = Physics2D.OverlapCircleAll(fb_object.transform.position, fb_aoeRange, enemyLayers);
                   
                   
                    foreach (Collider2D enemy in explosion)
                    {
                        fb_hitEnemies.Add(enemy.gameObject);
                        enemy.GetComponent<Enemy_Health>().TakeDamage(fb_damage);
                        GameObject enemyBurn = Instantiate(enemy_burn_vfx, enemy.transform.position, Quaternion.identity);
                        enemyBurn.transform.SetParent(enemy.transform);
                        StartCoroutine(Burning());
                        Destroy(enemyBurn, 5f);
                        
                    }
                    
                    Destroy(fb_object);
                    Destroy(explosion_obj, 2f);
                    
                }
               

            }
        }
        
        
    }
    
    void DisableCast()
    {
        casting = false;
        moveScript.moving = true;
    }
    
    void CastFireball()
    {
        fb_slider.value = fb_slider.maxValue;
        StartCoroutine(fb_StartCooldown());
        StartCoroutine(fb_SliderCooldown());
        mousepos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        fb_object = Instantiate(fireball, castPoint.position, Quaternion.identity);
        startMovement = true;
        

    }
    IEnumerator fb_StartCooldown()
    {
        fb_canCast = false;
        yield return new WaitForSeconds(fb_cooldown);
        fb_canCast = true;
    }

    IEnumerator fb_SliderCooldown()
    {
        float counter = 0;

        while (counter < fb_cooldown)
        {
            counter += Time.deltaTime;


            float time = fb_slider.value / (fb_cooldown - counter) * Time.deltaTime;
            fb_slider.value = Mathf.MoveTowards(fb_slider.value, fb_slider.minValue, time);

            yield return null;
        }
    }
    IEnumerator Burning()
    {
        float counter = 0;
        while(counter < burnTicks)
        {
            foreach (var enemy in fb_hitEnemies)
            {
                if(enemy != null)
                {
                    enemy.GetComponent<Enemy_Health>().TakeDamage(fb_burnDamage);
                }
                
            }
            counter++;
            yield return new WaitForSeconds(1f);
        }
        

    }

    void CastLightning()
    {
        lt_slider.value = lt_slider.maxValue;
        StartCoroutine(lt_StartCooldown());
        StartCoroutine(lt_SliderCooldown());
        mousepos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        lt_object = Instantiate(lightning, mousepos, Quaternion.identity);
        

    }
    IEnumerator lt_StartCooldown()
    {
        lt_canCast = false;
        yield return new WaitForSeconds(lt_cooldown);
        lt_canCast = true;
    }

    IEnumerator lt_SliderCooldown()
    {
        float counter = 0;

        while (counter < lt_cooldown)
        {
            counter += Time.deltaTime;


            float time = lt_slider.value / (lt_cooldown - counter) * Time.deltaTime;
            lt_slider.value = Mathf.MoveTowards(lt_slider.value, lt_slider.minValue, time);

            yield return null;
        }
    }
    private void OnDrawGizmos()
    {
        if(fb_object != null)
        {
            Gizmos.DrawSphere(fb_object.transform.position, fb_aoeRange);
        }
        
    }

}
