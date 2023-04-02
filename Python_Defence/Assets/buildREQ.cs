using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buildREQ : MonoBehaviour
{
    public ItemUIHandler resources;
    [SerializeField] private List<TMP_Text> infoResources;
    [SerializeField] private List<TMP_Text> needResources;
    [SerializeField] private TMP_Text errortext;
    [SerializeField] private GameObject pythonCanvas;
    private List<int> parsedInfo;
    private List<int> parsedNeed;
    private bool bought = false;
    List<string> mainList;
    private void OnEnable()
    {
        mainList = new List<string>()
        {
            resources.mainSrebro.text,
            resources.mainKamien.text,
            resources.mainHajs.text
        };
        infoResources[0].text = resources.mainSrebro.text;
        infoResources[1].text = resources.mainKamien.text;
        infoResources[2].text = resources.mainHajs.text;
        int index = 0;
        foreach (var item in infoResources)
        {
            parsedInfo[index] = int.Parse(item.text);
        }
        foreach (var item in needResources)
        {
            parsedNeed[index] = int.Parse(item.text);
        }
        if(bought)
        {
            pythonCanvas.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    void CheckCondition()
    {
        for (int i = 0; i < parsedInfo.Count; i++)
        {
            if (parsedInfo[i] >= parsedNeed[i])
            {
                bought = true;
                parsedInfo[i] -= parsedNeed[i];
                mainList[i] = parsedInfo[i].ToString();
                pythonCanvas.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                errortext.text = "Not enough minerals";
                errortext.color = Color.red;
            }
        }
    }

    
}
