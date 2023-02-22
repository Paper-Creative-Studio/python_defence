using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TradeButton : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private TMP_Text HajsKamien;
    //[SerializeField] private TMP_Text KamienHajs;
    //[SerializeField] private TMP_Text HajsSrebro;
    //[SerializeField] private TMP_Text SrebroHajs;
    //[SerializeField] private TMP_Text HajsGold;
    //[SerializeField] private TMP_Text GoldHajs;
    //[SerializeField] private TMP_Text KamienSrebro;
    //[SerializeField] private TMP_Text SrebroKamien;
    //[SerializeField] private TMP_Text SrebroGold;
    //[SerializeField] private TMP_Text GoldSrebro;
    public TMP_Text mineralToSell;
    public TMP_Text mineralToBuy;
    public TMP_Text sell;
    public TMP_Text buy;
    public GameObject canvasParent;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Kup()
    {
        int sellCount = int.Parse(sell.text);
        int buyCount = int.Parse(buy.text);
        int mineralSell = int.Parse(mineralToSell.text);
        int mineralBuy = int.Parse(mineralToBuy.text);
        Debug.Log(mineralSell + " " + sellCount);
        if (mineralSell >= sellCount)
        {
            mineralSell -= sellCount;
            mineralBuy += buyCount;
        }
        mineralToBuy.text = mineralBuy.ToString();
        mineralToSell.text = mineralSell.ToString();
        Debug.Log(mineralSell + " " + mineralBuy);
    }
    public void Close()
    {
        canvasParent.SetActive(false);
        player.GetComponent<Attacking>().canAttack = true;
        player.gameObject.GetComponent<movement>().moving = true;
    }
    
}
