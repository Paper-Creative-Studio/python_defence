using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectiveCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectiveCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                objectiveCanvas.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                objectiveCanvas.SetActive(true);
            }
        }
    }
}
