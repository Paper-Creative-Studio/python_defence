using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PythonDefence.Resources
{
    public class Resource
    {
        public TMP_Text counter;
        public int count;
        public Resource(int howMany, TMP_Text counter)
        {
            this.counter = counter;
            count = howMany;
            SetResource(howMany);
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
            counter.text = count.ToString();
        }
    }
}