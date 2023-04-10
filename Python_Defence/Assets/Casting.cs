using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Casting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera cam;
    [SerializeField] private Transform castPoint;
    [SerializeField] private LayerMask enemyLayers;
    private Health health;
    
    private bool startMovement = false;
    Vector3 mousepos;


    [Header("Fireball")]
    public bool fb_unlocked = false;
    [SerializeField] private int fb_damage = 50;
    [SerializeField] private GameObject fireball;
    [SerializeField] private float fb_speed;
    [SerializeField] private float fb_aoeRange;
    private bool fb_canCast = true;
    private GameObject fb_object;
    float fb_cooldown = 5f;
    [SerializeField] private Slider fb_slider;
    

    [Header("Lightning")]
    public bool lt_unlocked = false;
    [SerializeField] private float lt_damage = 35f;
    [SerializeField] private GameObject lightning;
    private bool lt_canCast = true;
    float lt_cooldown = 5f;


    void Start()
    {
        health= GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (fb_unlocked && Input.GetKeyDown(KeyCode.Z) && fb_canCast && fb_slider.value == 0)
        {
            CastFireball();
            fb_slider.value = fb_slider.maxValue;
            StartCoroutine(fb_StartCooldown());
            StartCoroutine(fb_SliderCooldown());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            
        }
        if(fb_object != null)
        {
            if (startMovement)
            {
                
                fb_object.transform.position = Vector3.MoveTowards(fb_object.transform.position, mousepos, fb_speed * Time.fixedDeltaTime);
               
                if (fb_object.transform.position == mousepos)
                {
                    Collider2D[] explosion = Physics2D.OverlapCircleAll(fb_object.transform.position, fb_aoeRange, enemyLayers);

                    foreach (Collider2D enemy in explosion)
                    {
                        enemy.GetComponent<Enemy_Health>().TakeDamage(fb_damage);
                    }
                    
                    Destroy(fb_object);
                    
                    
                }
               

            }
        }
        
        
    }
    void CastFireball()
    {
        
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

    IEnumerator lt_StartCooldown()
    {
        lt_canCast = false;
        yield return new WaitForSeconds(lt_cooldown);
        lt_canCast = true;
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

    //IEnumerator lt_SliderCooldown()
    //{
    //    float counter = 0;

    //    while (counter < lt_cooldown)
    //    {
    //        counter += Time.deltaTime;


    //        float time = dashSlider.value / (lt_cooldown - counter) * Time.deltaTime;
    //        dashSlider.value = Mathf.MoveTowards(dashSlider.value, dashSlider.minValue, time);

    //        yield return null;
    //    }
    //}
}
