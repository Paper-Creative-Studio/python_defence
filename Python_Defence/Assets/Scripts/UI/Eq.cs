using System.Collections;
using PythonDefence.Mark;
using TMPro;
using UnityEngine;

namespace PythonDefence.UI
{
    public class Eq : MonoBehaviour
    {
        [SerializeField] private TMP_Text kamienText;
        [SerializeField] private TMP_Text srebroText;
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private TMP_Text Hajstext;
        [SerializeField] private TMP_Text Silatext;
        //DataService dataService = new JsonDataService();
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
            zaznaczGold();
        }
        public void giveHajs(int count = 2)
        {
            HajsCount += count;
            Hajstext.text = HajsCount.ToString();
            zaznaczHajs();
        }
        public void ChangeStrength()
        {
            attackScript.damage += 20;
            silaCount = attackScript.damage * 3;
            Silatext.text = silaCount.ToString();
        }
        public void zaznaczGold()
        {
            goldText.color = Color.green;
            StartCoroutine(TurnBackToWhiteGold());
        }
        public void zaznaczHajs()
        {
            Hajstext.color = Color.green;
            StartCoroutine(TurnBackToWhiteHajs());
        }
        IEnumerator TurnBackToWhiteGold()
        {
            yield return new WaitForSecondsRealtime(2);
            goldText.color = Color.white;
        }
        IEnumerator TurnBackToWhiteHajs()
        {
            yield return new WaitForSecondsRealtime(2);
            Hajstext.color = Color.white;
        }
    }
}
