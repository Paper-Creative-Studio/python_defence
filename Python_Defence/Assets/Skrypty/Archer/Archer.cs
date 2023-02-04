using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    public Transform shootPoint;
    private bool canAttack = true;
    
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
            
            StartCoroutine(Cooldown());
        }
        
    }
    public void shootArrow()
    {
        Instantiate(arrow, shootPoint.position, Quaternion.identity);
       
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2);
        canAttack = true;
    }
}
