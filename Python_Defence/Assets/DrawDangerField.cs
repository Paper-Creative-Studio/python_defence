using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDangerField : MonoBehaviour
{
    [SerializeField] private LineRenderer circle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DrawCircle(int steps, float radius)
    {
        circle.positionCount= steps;
        for(int currentstep = 0; currentstep<steps;currentstep++)
        {
            float circumferenceProgress = (float)currentstep / steps;
            float radian = circumferenceProgress * 2 * Mathf.PI;
            float xOfCircle = Mathf.Cos(radian);
            float yOfCircle = Mathf.Sin(radian);
            float x = xOfCircle * radius;
            float y = yOfCircle * radius;
            Vector3 currentPos = new Vector3(x,y,0);
            circle.SetPosition(currentstep, currentPos);
        }
    }
}
