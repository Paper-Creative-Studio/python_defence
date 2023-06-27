using UnityEngine;

namespace PythonDefence.UI
{
    public class canvasAdjuster : MonoBehaviour
    {
        private Canvas canva;
        private UnityEngine.Camera cam;
        // Start is called before the first frame update
        void Start()
        {
            canva= GetComponent<Canvas>();
            cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            canva.worldCamera = cam;
        }
    }
}
