using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.Windows;


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
    int index;

    public void CheckCondition()
    {
        
        if (parsedInfo[0] >= parsedNeed[0] && parsedInfo[1] >= parsedNeed[1] && parsedInfo[2] >= parsedNeed[2] && parsedInfo[3] >= parsedNeed[3])
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
            errortext.text = "Not \r\nenough \r\nmaterials";
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
            if(UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                reqCanvas.SetActive(false);
                hpCanvas.SetActive(true);
                Time.timeScale = 1;
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
                    if (gameObject.name == "Ksiadz")
                    {
                        tasks[dialTrigger.Ksiadzindex].onSuccesful.Invoke();
                        previousindex = dialTrigger.Ksiadzindex;
                        dialTrigger.Ksiadzindex = 3;
                    }
                        
                    if (gameObject.name == "Gornik")
                    {
                        tasks[dialTrigger.Gornikindex].onSuccesful.Invoke();
                        previousindex = dialTrigger.Gornikindex;
                        dialTrigger.Gornikindex = 3;
                    }
                        
                    if (gameObject.name == "Kowal")
                    {
                        tasks[dialTrigger.Kowalindex].onSuccesful.Invoke();
                        previousindex = dialTrigger.Kowalindex;
                        dialTrigger.Kowalindex = 3;
                    }
                        
                    if (gameObject.name == "TypOdStajni")
                    {
                        tasks[dialTrigger.Stajniaindex].onSuccesful.Invoke();
                        previousindex = dialTrigger.Stajniaindex;
                        dialTrigger.Stajniaindex = 3;
                    }
                        
                    if (gameObject.name == "ArcherZbrojowania")
                    {
                        tasks[dialTrigger.Archerindex].onSuccesful.Invoke();
                        previousindex = dialTrigger.Archerindex;
                        dialTrigger.Archerindex = 3;
                    }
                        
                    if (gameObject.name == "Farmer")
                    {
                        tasks[dialTrigger.Farmerindex].onSuccesful.Invoke();
                        previousindex = dialTrigger.Farmerindex;
                        dialTrigger.Farmerindex = 3;
                    }
                        

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
                    if (gameObject.name == "Ksiadz")
                    {
                        if (dialTrigger.Ksiadzindex != 2)
                        {


                            dialTrigger.Ksiadzindex = previousindex;
                        }
                    }

                    if (gameObject.name == "Gornik")
                    {
                        if (dialTrigger.Gornikindex != 2)
                        {


                            dialTrigger.Gornikindex = previousindex;
                        }
                    }

                    if (gameObject.name == "Kowal")
                    {
                        if (dialTrigger.Kowalindex != 2)
                        {


                            dialTrigger.Kowalindex = previousindex;
                        }
                    }

                    if (gameObject.name == "TypOdStajni")
                    {
                        if (dialTrigger.Stajniaindex != 2)
                        {


                            dialTrigger.Stajniaindex = previousindex;
                        }
                    }

                    if (gameObject.name == "ArcherZbrojowania")
                    {
                        if (dialTrigger.Archerindex != 2)
                        {


                            dialTrigger.Archerindex = previousindex;
                        }
                    }

                    if (gameObject.name == "Farmer")
                    {
                        if (dialTrigger.Farmerindex != 2)
                        {
                            dialTrigger.Farmerindex = previousindex;
                        }
                    }
                    
                    
                    
                    if (!loop && stages.Count !=0)
                    {
                        Debug.Log(building.sprite);
                        
                        building.sprite = stages[0];
                        Debug.Log(building.sprite);
                        stages.RemoveAt(0);
                        var kolizje = building.gameObject.GetComponentsInChildren<Collider2D>();
                        if (stages.Count==1)
                        {
                            kolizje[0].enabled = true;
                            kolizje[1].enabled = true;
                            kolizje[2].enabled = true;
                            kolizje[3].enabled = true;
                            for (int i = 4; i < kolizje.Length; i++)
                            {
                                kolizje[i].enabled = false;
                            }
                            
                        }else if(stages.Count ==0)
                        {

                            kolizje[2].enabled = false;
                            kolizje[3].enabled = false;
                            kolizje[kolizje.Length-1].enabled = true;
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
                if (UnityEngine.Input.GetKeyDown(KeyCode.E))
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
        if (!bought && !loop)
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
        canvas.SetActive(true);
        if (gameObject.name == "Ksiadz")
        {
            skrypt.addition = tasks[dialTrigger.Ksiadzindex].addition;
            skrypt.desiredOutput = tasks[dialTrigger.Ksiadzindex].output;
            skrypt.secOutput = tasks[dialTrigger.Ksiadzindex].secondaryoutput;
            skrypt.polecenie = tasks[dialTrigger.Ksiadzindex].Polecenie;
            skrypt.stale = tasks[dialTrigger.Ksiadzindex].stale;
            skrypt.condition = tasks[dialTrigger.Ksiadzindex].condition;
        }
            
        if (gameObject.name == "Gornik")
        {
            skrypt.addition = tasks[dialTrigger.Ksiadzindex].addition;
            skrypt.desiredOutput = tasks[dialTrigger.Gornikindex].output;
            skrypt.secOutput = tasks[dialTrigger.Gornikindex].secondaryoutput;
            skrypt.polecenie = tasks[dialTrigger.Gornikindex].Polecenie;
            skrypt.stale = tasks[dialTrigger.Gornikindex].stale;
            skrypt.condition = tasks[dialTrigger.Gornikindex].condition;
        }
            
        if (gameObject.name == "Kowal")
        {
            skrypt.addition = tasks[dialTrigger.Ksiadzindex].addition;
            skrypt.desiredOutput = tasks[dialTrigger.Kowalindex].output;
            skrypt.secOutput = tasks[dialTrigger.Kowalindex].secondaryoutput;
            skrypt.polecenie = tasks[dialTrigger.Kowalindex].Polecenie;
            skrypt.stale = tasks[dialTrigger.Kowalindex].stale;
            skrypt.condition = tasks[dialTrigger.Kowalindex].condition;
        }

            
        if (gameObject.name == "TypOdStajni")
        {
            skrypt.addition = tasks[dialTrigger.Stajniaindex].addition;
            skrypt.desiredOutput = tasks[dialTrigger.Stajniaindex].output;
            skrypt.secOutput = tasks[dialTrigger.Stajniaindex].secondaryoutput;
            skrypt.polecenie = tasks[dialTrigger.Stajniaindex].Polecenie;
            skrypt.stale = tasks[dialTrigger.Stajniaindex].stale;
            skrypt.condition = tasks[dialTrigger.Stajniaindex].condition;
        }

            
        if (gameObject.name == "ArcherZbrojowania")
        {
            skrypt.addition = tasks[dialTrigger.Archerindex].addition;
            skrypt.desiredOutput = tasks[dialTrigger.Archerindex].output;
            skrypt.secOutput = tasks[dialTrigger.Archerindex].secondaryoutput;
            skrypt.polecenie = tasks[dialTrigger.Archerindex].Polecenie;
            skrypt.stale = tasks[dialTrigger.Archerindex].stale;
            skrypt.condition = tasks[dialTrigger.Archerindex].condition;
        }
            
        if (gameObject.name == "Farmer")
        {
            skrypt.addition = tasks[dialTrigger.Farmerindex].addition;
            skrypt.desiredOutput = tasks[dialTrigger.Farmerindex].output;
            skrypt.secOutput = tasks[dialTrigger.Farmerindex].secondaryoutput;
            skrypt.polecenie = tasks[dialTrigger.Farmerindex].Polecenie;
            skrypt.stale = tasks[dialTrigger.Farmerindex].stale;
            skrypt.condition = tasks[dialTrigger.Farmerindex].condition;
        }
            


        onNewTask.Invoke();
        hpCanvas.SetActive(false);
        Time.timeScale = 0;
    }
}
