using UnityEngine;

namespace PythonDefence.Compiler
{
    public class LeavePython : MonoBehaviour
    {
        [SerializeField] private GameObject hpCanvas;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void wyjdz()
        {
            transform.parent.parent.gameObject.SetActive(false);
            Time.timeScale = 1;
            hpCanvas.SetActive(true);
        }
    }
}
