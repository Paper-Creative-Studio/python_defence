using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHP : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
        }
    }
}
