using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private GameObject edge;
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    private void Update()
    {
        if (slider.value == 0)
        {
            edge.SetActive(false);
        }
        else
        {
            edge.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            slider.value -= 1;
        }

    }
}
