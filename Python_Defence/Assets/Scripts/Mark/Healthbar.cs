using UnityEngine;
using UnityEngine.UI;

namespace PythonDefence.Mark
{
    public class Healthbar : MonoBehaviour
    {

    
        [SerializeField] private Slider slider;
        // Start is called before the first frame update
   

        public void SetHealth(int health)
        {
            slider.value = health;
        }
        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }
    }
}
