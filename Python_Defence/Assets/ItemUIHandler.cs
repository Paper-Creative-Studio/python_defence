using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUIHandler : MonoBehaviour
{
    [SerializeField]private TMP_Text mainKamien;
    [SerializeField] private TMP_Text mainSrebro;
    [SerializeField] private TMP_Text mainGold;
    [SerializeField] private TMP_Text mainHajs;
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
