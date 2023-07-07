using System;
using System.Collections.Generic;
using PythonDefence.Compiler;
using PythonDefence.Resources;
using TMPro;
using UnityEngine;

namespace PythonDefence.Building
{
    public class buildREQ : MonoBehaviour
    {
        [SerializeField] private int[,] costs = new int[2, 3];
        
        [SerializeField] private GameObject pythonCanvas;
        [SerializeField] private GameObject hpCanvas;
        public GameObject reqCanvas;
        
        [SerializeField] private TMP_Text errorText;
        
        [SerializeField] private TMP_Text[] needResources;
        [SerializeField] private TMP_Text[] infoResources;
        
        [SerializeField] private Stats stats;
        private PythonGame pythonScript;
        private bool bought = false;
        [SerializeField] private int currentStage;
        private void Awake()
        {
            pythonScript = GetComponent<PythonGame>();
        }

        private void OnEnable()
        {
            infoResources[0].text = stats.Stone.counter.text;
            infoResources[1].text = stats.Iron.counter.text;
            infoResources[2].text = stats.Money.counter.text;

            for (int i = 0; i <= needResources.Length; i++)
            {
                needResources[i].text = costs[currentStage,i].ToString();
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
            for (int i = 0; i <= stats.AllResources.Length; i++) //sprawdzanie pokolei kazdego resourca, jesli za malo, returnuje i nie wykonuje dalszej czesci programu
            {
                if (stats.AllResources[i].count < costs[currentStage,i])
                {
                    errorText.text = "Not \r\nenough \r\nmaterials";
                    errorText.color = Color.red;
                    bought = false;
                    return;
                }
            }
            for (int i = 0; i <= stats.AllResources.Length; i++) //zmiana ilosci resourcow
            {
                stats.AllResources[i].SetResource(stats.AllResources[i].GetResource() - costs[currentStage,i]);
            }
                
            //zmiana statusu i wyswietlenie canvasa pythona
            bought = true;
            reqCanvas.SetActive(false);
            pythonScript.PythonCanvas();
        }
    
    
    }
}
