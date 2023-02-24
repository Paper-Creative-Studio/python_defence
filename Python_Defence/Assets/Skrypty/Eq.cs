using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Eq : MonoBehaviour
{
    [SerializeField] private TMP_Text kamienText;
    [SerializeField] private TMP_Text srebroText;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text Hajstext;
    public int kamienCount;
    public int srebroCount;
    public int GoldCount;
    public int HajsCount;
    // Start is called before the first frame update
    void Start()
    {
        kamienText.text = kamienCount.ToString();
        srebroText.text = srebroCount.ToString();
        goldText.text = GoldCount.ToString();
        Hajstext.text = HajsCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void giveGold()
    {
        GoldCount += 2;
        goldText.text = GoldCount.ToString();
    }
}
