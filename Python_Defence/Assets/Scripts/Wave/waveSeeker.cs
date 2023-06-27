using PythonDefence.Objective;
using UnityEngine;

namespace PythonDefence.Wave
{
    public class waveSeeker : MonoBehaviour
    {
        [SerializeField] private GameObject wavebutton;
        [SerializeField] private ObjectiveSetter objectiveScript;
        private WaveSpawner wavespawner;
        public bool enemy = false;
        // Start is called before the first frame update
        void Start()
        {
            wavespawner = wavebutton.GetComponent<WaveSpawner>();
        }

        // Update is called once per frame
        void Update()
        {
            if (enemy)
            {
                if (wavespawner.aliveEnemies.Count != 0)
                {
                    if (wavespawner.aliveEnemies[0] != null)
                    {
                        Vector3 dir = wavespawner.aliveEnemies[0].transform.position - transform.position;
                        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    }


                }
            }
            else
            {
                if (objectiveScript.objectives[0].placeToDo != null)
                {
                    Vector3 dir = objectiveScript.objectives[0].placeToDo.position - transform.position;
                    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
            
            }
        
        
        }
    }
}
