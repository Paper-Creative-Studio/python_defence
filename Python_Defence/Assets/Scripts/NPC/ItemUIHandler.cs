using System;
using TMPro;
using UnityEngine;
using PythonDefence.Resources;
namespace PythonDefence.NPC
{
    public class ItemUIHandler : MonoBehaviour
    {
        [SerializeField] private Stats stats;
        [SerializeField] TMP_Text[] tradeResources;
        private void OnEnable()
        {
            for (int i = 0; i < tradeResources.Length; i++)
            {
                tradeResources[i].text = stats.AllResources[i].counter.text;
            }
        }
        private void OnDisable()
        {
            for (int i = 0; i < tradeResources.Length; i++)
            {
                stats.AllResources[i].SetResource(Int32.Parse(tradeResources[i].text));
            }
        }
    }
}
