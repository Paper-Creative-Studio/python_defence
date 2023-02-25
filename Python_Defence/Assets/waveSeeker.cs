using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSeeker : MonoBehaviour
{
    [SerializeField] private GameObject wavebutton;
    private WaveSpawner wavespawner;
    // Start is called before the first frame update
    void Start()
    {
        wavespawner = wavebutton.GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wavespawner.aliveEnemies.Count != 0)
        {
            if (wavespawner.aliveEnemies[0] != null)
            {
                Vector3 dir = wavespawner.aliveEnemies[0].transform.position - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

           
        }
        
    }
}
