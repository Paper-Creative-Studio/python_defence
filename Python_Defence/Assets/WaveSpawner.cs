using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] enemies;
    public GameObject[] enemyWave1;
    public GameObject[] enemyWave2;
    public GameObject[] enemyWave3;
    public GameObject[] enemyWave4;
    public Transform[] spawnPoints;
    [SerializeField] private ObjectiveSetter objectivescript;
    public waveSeeker waveseeker;
    public int doneWaves = 0;
    private int waveCount = 1;
    public bool lose = false;
    public List<GameObject> aliveEnemies = new List<GameObject>();
    
    private bool wave;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

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
                Debug.Log(lose);
                if (!lose)
                {
                    
                    doneWaves++;
                        waveCount++;
                    
                    
                }
                objectivescript.description.text = objectivescript.objectives[0].CoZrobic;
                objectivescript.title.text = objectivescript.objectives[0].Title;
                waveseeker.enemy = false;
                lose = false;
                wave = false;
                
                if (waveCount > 4)
                {
                    waveCount = 1;
                }
                transform.position = new Vector3(transform.position.x, transform.position.y, 1);

            }
        }
        

        

    }
    public void Activate()
    {
        SpawnWave(waveCount);
        transform.position = new Vector3 (transform.position.x, transform.position.y, -1);
        waveseeker.enemy = true;
        Debug.Log("gasdowno");
        if (objectivescript.objectives[0].internalTitle != "Wave")
        {
            Debug.Log("gowno");
            objectivescript.title.text = "Monsters invasion";
            objectivescript.description.text = "Take out the monsters or they destroy our town";
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
