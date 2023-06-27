using UnityEngine;
using UnityEngine.UI;

namespace PythonDefence.Enemy
{
    public class Enemy_Healthbar : MonoBehaviour
    {
        [SerializeField] private Transform enemy;
        [SerializeField] private Slider slider;
        public Vector3 offset = new Vector3(-0.1f, 0.75f, 0);
        // Start is called before the first frame update
        void Start()
        {
       
       
        }
        private void Update()
        {
            transform.position = enemy.transform.position + offset;
        }

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

