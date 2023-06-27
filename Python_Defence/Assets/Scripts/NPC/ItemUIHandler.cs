using TMPro;
using UnityEngine;

namespace PythonDefence.NPC
{
    public class ItemUIHandler : MonoBehaviour
    {
        [SerializeField]public  TMP_Text mainKamien;
        [SerializeField] public  TMP_Text mainSrebro;
        [SerializeField] public  TMP_Text mainGold;
        [SerializeField] public  TMP_Text mainHajs;
        [SerializeField] private TMP_Text tradeKamien;
        [SerializeField] private TMP_Text tradeSrebro;
        [SerializeField] private TMP_Text tradeGold;
        [SerializeField] private TMP_Text tradeHajs;

        private void OnEnable()
        {
            tradeKamien.text = mainKamien.text;
            tradeSrebro.text = mainSrebro.text;
            tradeGold.text = mainGold.text;
            tradeHajs.text = mainHajs.text;
        }
        private void OnDisable()
        {
            mainKamien.text = tradeKamien.text;
            mainSrebro.text = tradeSrebro.text;
            mainGold.text = tradeGold.text;
            mainHajs.text = tradeHajs.text;
        }
    }
}
