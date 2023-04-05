using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.UIElements;

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
    public bool loop = false;
    [SerializeField] private farmamanagement farma;
    public Collider2D FirstCollider;

    [SerializeField] private  List<TMP_Text> resources;
    [SerializeField] private  List<TMP_Text> reqResources;
    [SerializeField] private List<TMP_Text> needResources;
    [SerializeField] private TMP_Text errortext;
    [SerializeField] private GameObject pythonCanvas;
    private List<int> parsedInfo = new List<int>();
    private List<int> parsedNeed = new List<int>();
    private bool bought = false;
    [SerializeField] GameObject reqCanvas;
    [SerializeField] UnityEngine.UI.Button buildButton;
    [SerializeField] private List<int> stage1Costs;
    [SerializeField] private List<int> stage2Costs;

    public void CheckCondition()
    {
        
        if (parsedInfo[0] >= parsedNeed[0] && parsedInfo[1] >= parsedNeed[1] && parsedInfo[2] >= parsedNeed[2])
        {
            for (int i = 0; i < parsedInfo.Count; i++)
            {
                parsedInfo[i] -= parsedNeed[i];
                resources[i].text = parsedInfo[i].ToString();
            }
            
            bought = true;
            reqCanvas.SetActive(false);
            PythonCanvas();
        }
        else
        {
            errortext.text = "Not enough materials";
            errortext.color = Color.red;
            bought = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
        skrypt = canvas.transform.GetChild(0).GetChild(0).GetComponent<compiler>();
        wavescript = waveSpawner.GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(reqCanvas.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                reqCanvas.SetActive(false);
            }
        }
        if (canvas.activeSelf == true)
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
                    Debug.Log("hp canvas jest true");
                    neededwaves = wavescript.doneWaves + 3;
                    doonce= false;
                }
                
                
                if(wavescript.doneWaves == neededwaves)
                {
                    if (objectiveScript.objectives[0].internalTitle == "Wave")
                    {
                        objectiveScript.NextObjective();
                    }
                    if(farma != null)
                    {
                        if (previousindex == 0 || previousindex == 1)
                        {
                            farma.Wyrosnij();
                        }
                    }
                    
                    if (previousindex != 2)
                    {
                        previousindex++;
                    }
                    if(loop && previousindex ==1)
                    {
                        previousindex = 2;
                    }
                    
                    if (dialTrigger.index != 2)
                    {

                        
                        dialTrigger.index = previousindex;
                    }
                    
                    
                    if (!loop)
                    {
                        Debug.Log(building.sprite);
                        
                        building.sprite = stages[0];
                        Debug.Log(building.sprite);
                        stages.RemoveAt(0);
                        if (stages.Count <=1)
                        {
                            building.gameObject.GetComponent<Collider2D>().enabled = true;
                            building.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                            

                        }
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
        buildButton.onClick.AddListener(this.CheckCondition);
        if (!bought)
        {
            Time.timeScale = 0;
            for (int i = 0; i < resources.Count; i++)
            {
                if (stages.Count > 1)
                {
                    needResources[i].text = stage1Costs[i].ToString();
                }
                else
                {
                    needResources[i].text = stage2Costs[i].ToString();
                }

                reqResources[i].text = resources[i].text;
                parsedInfo.Add(int.Parse(reqResources[i].text));
                parsedNeed.Add(int.Parse(needResources[i].text));
            }
            reqCanvas.SetActive(true);
        }
        else
        {
            PythonCanvas();
        }

    }
    public void PythonCanvas()
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
