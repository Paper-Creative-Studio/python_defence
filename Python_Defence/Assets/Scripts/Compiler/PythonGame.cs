using System.Collections.Generic;
using PythonDefence.Building;
using PythonDefence.Compiler;
using PythonDefence.Dialogue;
using PythonDefence.NPC;
using PythonDefence.Objective;
using PythonDefence.Wave;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace PythonDefence.Compiler
{
    public class PythonGame : MonoBehaviour
    {
        private buildREQ requirements;


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
        public UnityEvent onNewTask;
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
        public bool bought = false;
        
        [SerializeField] UnityEngine.UI.Button buildButton;
        public List<int> stage1Costs;
        public List<int> stage2Costs;
        int index;

    
        // Start is called before the first frame update
        void Start()
        {
            requirements = GetComponent<buildREQ>();
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
                    
                        if (!loop && stages.Count !=0)
                        {
                            building.sprite = stages[0];
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
    
        public void LaunchPython() // tu skonczyles / finito
        {
            buildButton.onClick.RemoveAllListeners();
            if (!bought && !loop)
            {
                requirements.reqCanvas.SetActive(true);
                buildButton.onClick.AddListener(requirements.CheckCondition);
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
       
            LoadTaskDets();
            onNewTask.Invoke();

            hpCanvas.SetActive(false);
            Time.timeScale = 0;
        }
        void LoadTaskDets()
        {
            skrypt.addition = tasks[dialTrigger.index].addition;
            skrypt.desiredOutput = tasks[dialTrigger.index].output;
            skrypt.secOutput = tasks[dialTrigger.index].secondaryoutput;
            skrypt.polecenie = tasks[dialTrigger.index].Polecenie;
            skrypt.stale = tasks[dialTrigger.index].stale;
            skrypt.condition = tasks[dialTrigger.index].condition;
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
       
    }
}
