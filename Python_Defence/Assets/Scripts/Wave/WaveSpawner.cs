using System.Collections.Generic;
using PythonDefence.Castle;
using PythonDefence.Objective;
using PythonDefence.UI;
using PythonDefence.Mark;
using UnityEngine;
using UnityEngine.UI;

namespace PythonDefence.Wave
{
    public class WaveSpawner : MonoBehaviour
    {
        public Transform spawnPoint;
        public GameObject[] enemies;
        public GameObject[] enemyWave1;
        public GameObject[] enemyWave2;
        public GameObject[] enemyWave3;
        public GameObject[] enemyWave4;
        public GameObject[] enemyWave5;
        public GameObject[] enemyWave6;
        public GameObject[] enemyWave7;
        public GameObject[] enemyWave8;
        public GameObject[] enemyWave9;
        public GameObject[] enemyWave10;
        public Transform[] spawnPoints;
        [SerializeField] private ObjectiveSetter objectivescript;
        public waveSeeker waveseeker;
        public int doneWaves = 0;
        private int waveCount = 1;
        public bool lose = false;
        public List<GameObject> aliveEnemies = new List<GameObject>();
        [SerializeField] private Eq eqscript;
        [SerializeField] private playmusic musicPlayer;
        [SerializeField] private AudioClip villageMusic;
        [SerializeField] private AudioClip BattleMusic;
        [SerializeField] private Health playerHP;
        [SerializeField] private CastleHealth castleHP;
        int wavesToHeal = 5;
        bool donce = true;
        private bool wave;
   
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(wavesToHeal == doneWaves)
            {
           
                castleHP.currentHealth = castleHP.maxHealth;
            
                castleHP.hpbar.SetHealth(castleHP.currentHealth);
                wavesToHeal = doneWaves + 5;
            }
            if(aliveEnemies.Count == 0)
            {
                if (donce)
                {
                    musicPlayer.source.Stop();
                    musicPlayer.source.clip = villageMusic;
                    musicPlayer.source.Play();
                    donce = false;
                }
            }
            else
            {
                if (!donce)
                {
                    musicPlayer.source.Stop();
                    musicPlayer.source.clip = BattleMusic;
                    musicPlayer.source.Play();
                    donce = true;
                }

            }


            if (wave)
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
                
                
                    if (!lose)
                    {
                        eqscript.giveHajs((doneWaves +1) * 2);
                        playerHP.currentHealth = playerHP.maxHealth;
                        playerHP.healthbar.SetHealth(playerHP.currentHealth);
                        doneWaves++;
                        waveCount++;
                        Debug.Log("leci");
                    
                    }
                    objectivescript.description.text = objectivescript.objectives[0].CoZrobic;
                    objectivescript.title.text = objectivescript.objectives[0].Title;
                    waveseeker.enemy = false;
                    lose = false;
                    wave = false;
                    Debug.Log("stop");
                    if (waveCount > 10)
                    {
                        waveCount = 1;
                    }
                    transform.position = new Vector3(transform.position.x, transform.position.y, 1);
                    gameObject.GetComponent<Button>().interactable = true;

                }
            
            }
        

        


        }
        public void Activate()
        {
            SpawnWave(waveCount);
            transform.position = new Vector3 (transform.position.x, transform.position.y, -1);
            gameObject.GetComponent<Button>().interactable= false;
            waveseeker.enemy = true;
       
            if (objectivescript.objectives[0].internalTitle != "Wave")
            {
            
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
            else if (waveNumber == 5)
            {
                wave = true;



                for (int i = 0; i <= enemyWave5.Length - 1; i++)
                {


                    aliveEnemies.Add((GameObject)Instantiate(enemyWave5[i], spawnPoints[i].position, Quaternion.identity));





                }

            }
            else if (waveNumber == 6)
            {
                wave = true;



                for (int i = 0; i <= enemyWave6.Length - 1; i++)
                {


                    aliveEnemies.Add((GameObject)Instantiate(enemyWave6[i], spawnPoints[i].position, Quaternion.identity));





                }

            }
            else if (waveNumber == 7)
            {
                wave = true;



                for (int i = 0; i <= enemyWave7.Length - 1; i++)
                {


                    aliveEnemies.Add((GameObject)Instantiate(enemyWave7[i], spawnPoints[i].position, Quaternion.identity));





                }

            }
            else if (waveNumber == 8)
            {
                wave = true;



                for (int i = 0; i <= enemyWave8.Length - 1; i++)
                {


                    aliveEnemies.Add((GameObject)Instantiate(enemyWave8[i], spawnPoints[i].position, Quaternion.identity));





                }

            }
            else if (waveNumber == 9)
            {
                wave = true;



                for (int i = 0; i <= enemyWave9.Length - 1; i++)
                {


                    aliveEnemies.Add((GameObject)Instantiate(enemyWave9[i], spawnPoints[i].position, Quaternion.identity));





                }

            }
            else if (waveNumber == 10)
            {
                wave = true;



                for (int i = 0; i <= enemyWave10.Length - 1; i++)
                {


                    aliveEnemies.Add((GameObject)Instantiate(enemyWave10[i], spawnPoints[i].position, Quaternion.identity));





                }

            }




        }
    
    
    }
}
