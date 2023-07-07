using System;
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
    public class NPCProperties : MonoBehaviour
    {
        private buildREQ requirements;

        
        public List<Task> tasks;
        public GameObject canvas;
        public GameObject hpCanvas;
        private compiler compiler;
        public bool result;
        public SpriteRenderer building;
        public List<Sprite> stages = new List<Sprite>();
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
        bool doonce = true;
        [SerializeField] private DialogueTrigger dialTrigger;
        private int previousindex;
        [SerializeField] private string ownTask;
        public bool loop = false;
        [SerializeField] private farmamanagement farma;
       
        public bool bought = false;
        
        [SerializeField] UnityEngine.UI.Button buildButton;
        public List<int> stage1Costs;
        public List<int> stage2Costs;
        int index;

    
        // Start is called before the first frame update
        void Start()
        {
            requirements = GetComponent<buildREQ>();
            compiler = canvas.transform.GetChild(0).GetChild(0).GetComponent<compiler>();
            wavescript = waveSpawner.GetComponent<WaveHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            if (canvas.activeSelf == true) //zmienna coding true/false
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

        public void TaskPassed()
        { 
            previousindex = dialTrigger.index;
            dialTrigger.index = 3;
            hpCanvas.SetActive(true);
            wavescript.neededwaves = wavescript.doneWaves + 3;
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
            //index handle
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
            if (!loop && stages.Count !=0) //kolizje - do zmiany
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
