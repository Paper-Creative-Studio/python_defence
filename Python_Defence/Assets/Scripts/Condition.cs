using PythonDefence.Mark;
using UnityEngine;

namespace PythonDefence
{
    public class Condition : MonoBehaviour
    {
        // Start is called before the first frame update
        movement movement;
        Attacking attacking;
        Casting casting;
        void Start()
        {
            movement = GetComponent<movement>();
            attacking = GetComponent<Attacking>();
            casting = GetComponent<Casting>();
        }

        // Update is called once per frame
        void Update() 
        {
        
        }
        public bool Check()
        {
            if(movement.dodging || movement.dashing || movement.attacking || attacking.stunned || casting.casting || Time.timeScale ==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
