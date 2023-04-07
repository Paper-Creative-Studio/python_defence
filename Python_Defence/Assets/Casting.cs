using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform castPoint;
    [SerializeField] private LayerMask enemyLayers;
    [Header("Fireball")]
    public bool fb_unlocked = false;
    [SerializeField] private int fb_damage = 50;
    [SerializeField] private GameObject fireball;
    [SerializeField] private float fb_speed;
    [SerializeField] private float fb_aoeRange;
    private GameObject fb_object;
    private bool startMovement = false;
    Vector3 mousepos;
    [Header("Lightning")]
    public bool lt_unlocked = false;
    [SerializeField] private float lt_damage = 35f;
    [SerializeField] private GameObject lightning;
    private Health health;
    [SerializeField] private Camera cam;
    void Start()
    {
        health= GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fb_object);
        if (fb_unlocked && Input.GetKeyDown(KeyCode.Z))
        {
            CastFireball();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            
        }
        if(fb_object != null)
        {
            if (startMovement)
            {
                Debug.Log("3");
                fb_object.transform.position = Vector3.MoveTowards(fb_object.transform.position, mousepos, fb_speed * Time.fixedDeltaTime);
               
                if (fb_object.transform.position == mousepos)
                {
                    Collider2D[] explosion = Physics2D.OverlapCircleAll(fb_object.transform.position, fb_aoeRange, enemyLayers);

                    foreach (Collider2D enemy in explosion)
                    {
                        enemy.GetComponent<Enemy_Health>().TakeDamage(fb_damage);
                    }
                    
                    Destroy(fb_object);
                    
                    Debug.Log("4");
                }
               

            }
        }
        
        
    }
    void CastFireball()
    {
        Debug.Log("1");
        mousepos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
        fb_object = Instantiate(fireball, castPoint.position, Quaternion.identity);
        startMovement = true;
        Debug.Log("2");

    }
   


}
