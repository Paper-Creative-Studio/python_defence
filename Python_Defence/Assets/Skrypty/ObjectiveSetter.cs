using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveSetter : MonoBehaviour
{
    public List<Objective> objectives = new List<Objective>();
    public TMP_Text title;
    public TMP_Text description;
    // Start is called before the first frame update
    void Start()
    {
        description.text = objectives[0].CoZrobic;
        title.text = objectives[0].Title;
    }

    // Update is called once per frame
    void Update()
    {

        
            
    }
    public void NextObjective()
    {
        gameObject.SetActive(true);
        objectives.RemoveAt(0);
        description.text = objectives[0].CoZrobic;
        title.text = objectives[0].Title;
    }
}
