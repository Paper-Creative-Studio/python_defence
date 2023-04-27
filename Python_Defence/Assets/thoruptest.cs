using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class thoruptest : MonoBehaviour
{
    [SerializeField] AnimationCurve curveY;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ThrowUp());
            
        }
    }
    IEnumerator ThrowUp()
    {
        Debug.Log("gowno");
        Vector2 ppos = transform.position;
        float timeElapsed = 0f;
        bool playerOnGround = true;
        do
        {
            if (playerOnGround)
            {
                timeElapsed = 0f;
                playerOnGround = false;
            }
            else
            {
                timeElapsed += Time.fixedDeltaTime * 1;
                if (timeElapsed <= 1f)
                {
                    Debug.Log(timeElapsed +  " " + new Vector2(ppos.x, ppos.y + curveY.Evaluate(timeElapsed) * 5f));
                    rb.MovePosition(new Vector2(ppos.x, ppos.y + curveY.Evaluate(timeElapsed) * 5f));
                }
                else
                {
                    playerOnGround = true;
                }
            }
        } while (timeElapsed < 1f);
        
        yield return new WaitForEndOfFrame();

    }
}
