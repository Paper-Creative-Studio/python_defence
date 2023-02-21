using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PythonGame : MonoBehaviour
{
    public string output;
    public GameObject canvas;
    public GameObject hpCanvas;
    private compiler skrypt;
    public SpriteRenderer dependentBuilding;
    public List<Sprite> nextStages;
    // Start is called before the first frame update
    void Start()
    {
        skrypt = canvas.transform.GetChild(0).GetComponent<compiler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(skrypt.result && Time.timeScale == 1)
        {
            dependentBuilding.sprite = nextStages[0];
            nextStages.RemoveAt(0);
            if(nextStages.Count == 0)
            {
                dependentBuilding.gameObject.GetComponent<Collider2D>().enabled = true;
                dependentBuilding.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
            skrypt.result = false;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(nextStages.Count != 0)
        {
            if (collision.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canvas.SetActive(true);

                    skrypt.desiredOutput = output;
                    hpCanvas.SetActive(false);
                    Time.timeScale = 0;
                }
            }
        }
        
    }
}
