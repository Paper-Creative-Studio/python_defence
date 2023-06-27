using System.Collections;
using Pathfinding;
using UnityEngine;

namespace PythonDefence.Enemy
{
    public class stun : MonoBehaviour
    {
        public bool stunned = false;
        public AIDestinationSetter AI;
        private Animator objectAnim;
        // Start is called before the first frame update
        void Start()
        {
            AI = gameObject.GetComponent<AIDestinationSetter>();
            objectAnim = transform.GetChild(0).GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(stunned)
            {
                objectAnim.SetBool("Shock", true);
                StartCoroutine(StopStun());
                stunned= false;
            }
        }
        IEnumerator StopStun()
        {
            yield return new WaitForSeconds(3f);
            objectAnim.SetBool("Shock", false);
            AI.ai.canMove = true;
            AI.canChange = true;
            transform.GetChild(0).GetComponent<Attack_Enemy>().stunned = false;

        }
    }
}
