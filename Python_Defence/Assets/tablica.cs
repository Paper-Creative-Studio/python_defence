using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tablica : MonoBehaviour
{
    bool inarea = false;
    [SerializeField] private GameObject tablicaCanvas;
    [SerializeField] private ObjectiveSetter objectiveScript;
    public string ownTask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (inarea && Input.GetKeyDown(KeyCode.E))
        {
            if (objectiveScript.objectives[0].internalTitle == ownTask)
            {
                objectiveScript.NextObjective();
            }
            tablicaCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inarea= true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inarea = false;
    }
}
