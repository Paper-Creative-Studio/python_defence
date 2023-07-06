using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PythonDefence.Resources
{
    public class Resource: MonoBehaviour
    {
        public TMP_Text counter;
        public int count;
        public Resource(int howMany, TMP_Text counter)
        {
            count = howMany;
            this.counter = counter;
            
        }

        public int GetResource()
        {
            return count;
        }

        public void SetResource(int howMany)
        {
            count = howMany;
            counter.text = count.ToString();
        }
        public void AddResource(int howMany)
        {
            count += howMany;
            counter.text += count.ToString();
        }
        public void HighlightResource(int howLong)
        {
            counter.color = Color.green;
            Invoke("SetColorWhite", howLong);
        }
        public void GiveResource(int count)
        {
            AddResource(count);
            HighlightResource(2);
        }
        void SetColorWhite()
        {
            counter.color = Color.white;
        }
    }
}