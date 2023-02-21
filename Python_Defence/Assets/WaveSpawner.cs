using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] enemies;
    public GameObject[] enemyWave1;
    public GameObject[] enemyWave2;
    public GameObject[] enemyWave3;
    public GameObject[] enemyWave4;
    public Transform[] spawnPoints;
    private int waveCount = 1;
    public List<GameObject> aliveEnemies = new List<GameObject>();
    
    private bool wave;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnWave(waveCount);
            waveCount++;
        }

        if(wave)
        {
            for (int i = 0; i <= aliveEnemies.Count - 1; i++)
            {
                
                if (aliveEnemies[i] == null)
                {
                    
                    aliveEnemies.RemoveAt(i);
                }
            }
            if (aliveEnemies.Count == 0)
            {
                
                wave = false;
                SpawnWave(waveCount);
                if(waveCount < 4)
                {
                    waveCount++;
                }
                
            }
        }
        

        

    }
    void SpawnWave(int waveNumber)
    {
        if (waveNumber == 1)
        {
            wave = true;
           


            for (int i= 0; i <= enemyWave1.Length - 1; i++)
            {
                
                
                    aliveEnemies.Add((GameObject)Instantiate(enemyWave1[i], spawnPoints[i].position, Quaternion.identity));
                




            }

        }
        else if(waveNumber == 2)
        {
            wave = true;



            for (int i = 0; i <= enemyWave2.Length - 1; i++)
            {


                aliveEnemies.Add((GameObject)Instantiate(enemyWave2[i], spawnPoints[i].position, Quaternion.identity));





            }
        }
        else if(waveNumber == 3)
        {
            wave = true;



            for (int i = 0; i <= enemyWave3.Length - 1; i++)
            {


                aliveEnemies.Add((GameObject)Instantiate(enemyWave3[i], spawnPoints[i].position, Quaternion.identity));





            }
        }
        else if(waveNumber == 4)
        {
            wave = true;



            for (int i = 0; i <= enemyWave4.Length - 1; i++)
            {


                aliveEnemies.Add((GameObject)Instantiate(enemyWave4[i], spawnPoints[i].position, Quaternion.identity));





            }

        }
        
       
        

    }
    
    
}
