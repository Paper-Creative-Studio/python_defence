using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PythonGame : MonoBehaviour
{
    public string output;
    public GameObject canvas;
    public GameObject hpCanvas;
    private compiler skrypt;
    public SpriteRenderer building;
    public List<Sprite> stages = new List<Sprite>();
    private bool talk;
    public bool talking;
    [SerializeField] private UnityEvent onInteract;
    public string aftermath;
    [SerializeField] private GameObject waveSpawner;
    private WaveSpawner wavescript;
    private int neededwaves;
    bool doonce = true;
    // Start is called before the first frame update
    void Start()
    {
        skrypt = canvas.transform.GetChild(0).GetChild(0).GetComponent<compiler>();
        wavescript = waveSpawner.GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (skrypt != null)
        {
           
            if (skrypt.result && Time.timeScale == 1)
            {
                if(doonce)
                {
                    hpCanvas.SetActive(true);
                    neededwaves = wavescript.doneWaves + 3;
                    doonce= false;
                }
                
                
                if(wavescript.doneWaves == neededwaves)
                {
                    building.sprite = stages[0];
                    stages.RemoveAt(0);
                    if (stages.Count == 0)
                    {
                        building.gameObject.GetComponent<Collider2D>().enabled = true;
                        building.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        
                        doonce = true;
                    }
                    skrypt.result = false;
                }
                
                
            }
        }
        if(talk)
        {
            if(!talking)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    onInteract.Invoke();


                }
            }
            
        }
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talk = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talk = false;
        }
    }
    public void LaunchPython()
    {
        canvas.SetActive(true);
        skrypt.desiredOutput = output;
        hpCanvas.SetActive(false);
        Time.timeScale = 0;
    }
}
