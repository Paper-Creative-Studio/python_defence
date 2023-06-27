using UnityEngine;
using UnityEngine.Events;

namespace PythonDefence.Castle
{
    public class CastleHealth : MonoBehaviour
    {
        public CastleHealthbar hpbar;
        public int maxHealth = 100;
        public int currentHealth;
        public int damage;
        public DeathTrigger deathtrigger;
        public Sprite iconSprite;
        [TextArea]
        public string texttext;
        [TextArea]
        public string tiptext;
        private bool doonce = true;
        [SerializeField] private UnityEvent onDestruction;
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            hpbar.SetMaxHealth(currentHealth);
        }
        private void Update()
        {
            if(currentHealth <= 0)
            {
                if (doonce)
                {
                    deathtrigger.iconSprite = iconSprite;
                    deathtrigger.texttext = texttext;
                    deathtrigger.tiptext = tiptext;
                    onDestruction.Invoke();
                    doonce = false;
                    currentHealth = maxHealth;
                    hpbar.SetHealth(currentHealth);

                }
            }
       
        }
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            hpbar.SetHealth(currentHealth);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
        
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Halo karhus");
                Destroy(collision.transform.parent.gameObject);
                TakeDamage(damage);

            }
        }
    }
}
