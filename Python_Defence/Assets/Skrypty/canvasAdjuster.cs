using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasAdjuster : MonoBehaviour
{
    private Canvas canva;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        canva= GetComponent<Canvas>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        canva.worldCamera = cam;
    }
}
