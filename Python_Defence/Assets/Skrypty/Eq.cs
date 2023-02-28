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
    [SerializeField] private TMP_Text Silatext;

    public int kamienCount;
    public int srebroCount;
    public int GoldCount;
    public int HajsCount;
    public int silaCount;
    private Attacking attackScript;
    // Start is called before the first frame update
    void Start()
    {
        kamienText.text = kamienCount.ToString();
        srebroText.text = srebroCount.ToString();
        goldText.text = GoldCount.ToString();
        Hajstext.text = HajsCount.ToString();
        attackScript = GetComponent<Attacking>();
        silaCount = attackScript.damage * 3;
        Silatext.text = silaCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void giveGold(int count = 2)
    {
        GoldCount += count;
        goldText.text = GoldCount.ToString();
    }
    public void giveHajs(int count = 2)
    {
        HajsCount += count;
        Hajstext.text = HajsCount.ToString();
    }
    public void ChangeStrength()
    {
        attackScript.damage += 20;
        silaCount = attackScript.damage * 3;
        Silatext.text = silaCount.ToString();
    }
}
