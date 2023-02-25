using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PythonGame : MonoBehaviour
{



    public List<Task> tasks;
    public GameObject canvas;
    public GameObject hpCanvas;
    private compiler skrypt;
    public bool result;
    public SpriteRenderer building;
    public List<Sprite> stages = new List<Sprite>();
    private bool talk;
    public bool talking;
    [SerializeField] private UnityEvent onInteract;
    [SerializeField] private UnityEvent onNewTask;
    public string aftermath;
    [SerializeField] private GameObject waveSpawner;
    private WaveSpawner wavescript;
    private int neededwaves;
    private bool coding = false;
    [SerializeField] private ObjectiveSetter objectiveScript;
    bool doonce = true;
    [SerializeField] private DialogueTrigger dialTrigger;
    private int previousindex;
    [SerializeField] private string ownTask;
    // Start is called before the first frame update
    void Start()
    {
        
        skrypt = canvas.transform.GetChild(0).GetChild(0).GetComponent<compiler>();
        wavescript = waveSpawner.GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(canvas.activeSelf == true)
        {
            coding = true;
        }
        else
        {
            coding = false;
        }
       
        if (skrypt != null)
        {
            
            if (result && Time.timeScale == 1)
            {
                

                if (doonce)
                {
                    if (objectiveScript.objectives[0].internalTitle == ownTask)
                    {
                        objectiveScript.NextObjective();
                    }
                    tasks[dialTrigger.index].onSuccesful.Invoke();
                    previousindex = dialTrigger.index;
                    dialTrigger.index = 3;
                    hpCanvas.SetActive(true);
                    neededwaves = wavescript.doneWaves + 3;
                    doonce= false;
                }
                
                
                if(wavescript.doneWaves == neededwaves)
                {
                    if (objectiveScript.objectives[0].internalTitle == "Wave")
                    {
                        objectiveScript.NextObjective();
                    }
                    if (previousindex != 2)
                    {
                        previousindex++;
                    }
                    if(dialTrigger.index != 2)
                    {

                        
                        dialTrigger.index = previousindex;
                    }
                    
                    building.sprite = stages[0];
                    stages.RemoveAt(0);
                    if (stages.Count == 0)
                    {
                        building.gameObject.GetComponent<Collider2D>().enabled = true;
                        building.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                        
                        
                    }
                    doonce = true;
                    result = false;
                }
                
                
            }
        }
        if(talk)
        {
            if(!talking)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!coding)
                    {
                        
                        onInteract.Invoke();
                        
                    }
                    


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
        skrypt.scriptwyw = this;
        coding = true;
        skrypt.addition = tasks[dialTrigger.index].addition;
        canvas.SetActive(true);
        skrypt.desiredOutput = tasks[dialTrigger.index].output;
        skrypt.secOutput = tasks[dialTrigger.index].secondaryoutput;
        skrypt.polecenie = tasks[dialTrigger.index].Polecenie;
        skrypt.stale = tasks[dialTrigger.index].stale;
        skrypt.condition = tasks[dialTrigger.index].condition;
        onNewTask.Invoke();
        hpCanvas.SetActive(false);
        Time.timeScale = 0;
    }
}
