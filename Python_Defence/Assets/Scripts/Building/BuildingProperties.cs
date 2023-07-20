using System;
using System.Collections.Generic;
using PythonDefence.NPC;
using PythonDefence.Resources;
using TMPro;
using UnityEngine;

namespace PythonDefence.Building
{
    public class BuildingProperties : MonoBehaviour
    {
        [SerializeField] private GameObject pythonCanvas;
        [SerializeField] private GameObject hpCanvas;
        public GameObject reqCanvas;
        
        [SerializeField] private TMP_Text errorText;
        
        [SerializeField] private TMP_Text[] needResources;
        [SerializeField] TMP_Text[] infoResources;
        
        [SerializeField] private Stats stats;
        
        public BuildingStage[] stages;
        
        [SerializeField] NPCProperties Controllingnpc;
        
        private bool bought = false;
        
        [SerializeField] private int currentStage;

        private SpriteRenderer buildingLook;

        private Collider2D[] colliders;
        private void Start()
        {
            buildingLook = GetComponent<SpriteRenderer>();
            colliders = GetComponents<Collider2D>();
        }

        public void BuildingREQ()
        {
            infoResources[0].text = stats.Stone.counter.text;
            infoResources[1].text = stats.Iron.counter.text;
            infoResources[2].text = stats.Gold.counter.text;
            infoResources[3].text = stats.Money.counter.text;

            for (int i = 0; i <= needResources.Length-1; i++)
            {
                needResources[i].text = stages[0].nextStageCost[i].ToString();
            }
            if(bought)
            {
                pythonCanvas.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if(reqCanvas.activeSelf)
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    reqCanvas.SetActive(false);
                    hpCanvas.SetActive(true);
                    Time.timeScale = 1;
                }
            }
        }

        public void CheckCondition()
        {
            errorText.text = string.Empty;
            for (int i = 0; i <= stats.AllResources.Length -1; i++) 
            {
                if (stats.AllResources[i].count < stages[currentStage].nextStageCost[i])
                {
                    errorText.text = "Not \r\nenough \r\nmaterials";
                    errorText.color = Color.red;
                    bought = false;
                    return;
                }
            }
            for (int i = 0; i <= stats.AllResources.Length-1; i++) 
            {
                stats.AllResources[i].SetResource(stats.AllResources[i].GetResource() - stages[currentStage].nextStageCost[i]);
            }
            bought = true;
            reqCanvas.SetActive(false);
            Controllingnpc.PythonCanvas();
        }

        public void LevelUpBuilding()
        {
            
            if (!Controllingnpc.isNotFarmer && currentStage != 2)
            {
                foreach (var collider in colliders)
                {
                    collider.enabled = false;  
                }
                buildingLook.sprite = stages[currentStage].sprite;
                foreach (var collider in stages[currentStage].colliders)
                {
                    collider.enabled = true;
                }

                currentStage++;
            }
        }
    
    
    }
}
