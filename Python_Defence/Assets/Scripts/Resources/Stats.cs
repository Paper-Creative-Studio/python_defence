using PythonDefence.Mark;
using TMPro;
using UnityEngine;

namespace PythonDefence.Resources
{
    public class Stats : MonoBehaviour
    {
        public Resource Stone,Iron,Gold,Money,Strength;
        [SerializeField] private int stoneCount, ironCount, goldCount, moneyCount;
        [SerializeField] private TMP_Text[] counters;
        private Attacking attack;

        public Resource[] AllResources;
        // Start is called before the first frame update
        void Awake()
        {
            attack = GetComponent<Attacking>();
            Stone = new Resource(stoneCount, counters[0]);
            Iron = new Resource(ironCount, counters[1]);
            Gold = new Resource(goldCount, counters[2]);
            Money = new Resource(moneyCount, counters[3]);
            Strength = new Resource(attack.damage * 3, counters[4]);
            AllResources = new Resource[] { Stone, Iron, Gold, Money};
        }
        
        public void ChangeStrength(int count)
        {
            attack.damage += count;
            Strength.AddResource(count);
        }
        //public void giveGold(int count = 2)
        //{
        //    Resources.Gold += count;
        //    goldCounter.SetResourceCount(Resources.Gold);
        //    goldCounter.HighlightResource(2);
        //}
       
        //public void giveHajs(int count = 2)
        //{
        //    Resources.Money += count;
        //    moneyCounter.SetResourceCount(Resources.Money);
        //    moneyCounter.HighlightResource(2);  
        //}

        
    }
}
