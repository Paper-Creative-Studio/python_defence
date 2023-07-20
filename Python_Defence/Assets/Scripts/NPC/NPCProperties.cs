using System.Collections.Generic;
using IronPython.Modules;
using PythonDefence.Building;
using PythonDefence.Dialogue;
using PythonDefence.Compiler;
using PythonDefence.Objective;
using PythonDefence.Wave;
using UnityEngine;
using UnityEngine.Events;

namespace PythonDefence.NPC
{
    public class NPCProperties : MonoBehaviour
    {
        [SerializeField] private BuildingProperties buildingProp;
        
        public SpriteRenderer DependantBuilding;

        
        public List<Task> tasks;
        public GameObject canvas;
        public GameObject hpCanvas;
        private compiler compiler;
        private bool talk;
        public bool talking;
        [SerializeField] private UnityEvent onInteract;
        public UnityEvent onNewTask;
        public string aftermath;
        [SerializeField] private GameObject waveSpawner;
        private WaveHandler wavescript;
        private int neededwaves;
        private bool coding = false;
        [SerializeField] private ObjectiveSetter objectiveScript;
        [SerializeField] private DialogueTrigger dialTrigger;
        private int previousindex;
        [SerializeField] private string ownTask;
        public bool isNotFarmer = false;
        [SerializeField] private farmamanagement farma;
       
        public bool bought = false;
        
        [SerializeField] UnityEngine.UI.Button buildButton;
        public List<int> stage1Costs;
        public List<int> stage2Costs;
        int index;

    
        // Start is called before the first frame update
        void Start()
        {
            compiler = canvas.transform.GetChild(0).GetChild(0).GetComponent<compiler>();
            wavescript = waveSpawner.GetComponent<WaveHandler>();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (canvas.activeSelf == true) 
            {
                coding = true; 
            }
            else
            {
                coding = false;
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

            if (wavescript.doneWaves == neededwaves && dialTrigger.index == 3)
            {
                if (objectiveScript.objectives[0].internalTitle == "Wave")
                {
                    objectiveScript.NextObjective();
                }
                dialTrigger.index = previousindex;
                
            }
        }

        public void TaskPassed()
        { 
            previousindex = dialTrigger.index;
            dialTrigger.index = 3;
          
            neededwaves = wavescript.doneWaves + 3;
            if (objectiveScript.objectives[0].internalTitle == ownTask)
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
            HandleIndexes();
            
        }
        
        public void LaunchPython()
        {
            Time.timeScale = 0;
            buildButton.onClick.RemoveAllListeners();
            if (!bought && !isNotFarmer)
            {
                buildingProp.reqCanvas.SetActive(true);
                buildingProp.BuildingREQ();
                buildButton.onClick.AddListener(buildingProp.CheckCondition);
            }
            else
            {
                PythonCanvas();
            }

        }

        public void PythonCanvas()
        {
            compiler.NPCCaller = this;
            coding = true;
            canvas.SetActive(true);

            LoadTaskDets();
            onNewTask.Invoke();

            hpCanvas.SetActive(false);
            Time.timeScale = 0;
        }

        void LoadTaskDets()
        {
            compiler.addition = tasks[dialTrigger.index].addition;
            compiler.desiredOutput = tasks[dialTrigger.index].output;
            compiler.secOutput = tasks[dialTrigger.index].secondaryoutput;
            compiler.polecenie = tasks[dialTrigger.index].Polecenie;
            compiler.stale = tasks[dialTrigger.index].stale;
            compiler.condition = tasks[dialTrigger.index].condition;
        }
       
        void HandleIndexes()
        {
            if (previousindex != 2 || !isNotFarmer && previousindex!=1)
            {
                previousindex++;
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
       
    }
}
