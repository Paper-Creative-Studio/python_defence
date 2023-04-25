using UnityEngine;
using System.Collections;
using Microsoft.Scripting.Actions;
using System.IO;

namespace Pathfinding 
{
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour 
	{
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		public Transform SecondaryTarget;
		public float viewRange;
		public IAstarAI ai;
		private float dist;
		public float lostRange;
		public Animator anim;
		public float CastleSpeed;
		public float PlayerSpeed;
		public float stopRange;
		public bool move;
        public AIPath aipath;
		private Transform enemyObject;
        public bool canChange = true;
        public bool stunned = false;
        void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
			

        }
        private void Start()
        {
			enemyObject = transform.GetChild(0);
            SecondaryTarget = GameObject.FindGameObjectWithTag("Player").transform;
            target = GameObject.FindGameObjectWithTag("EndGoal").transform;
        }
        void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () 
		{
           
			if(target != null)
			{
                dist = Vector3.Distance(SecondaryTarget.position, enemyObject.position);

                if (dist <= viewRange)
                {
                    if (target != null && ai != null && canChange)
                    {
                        ai.destination = SecondaryTarget.position;
                        ai.maxSpeed = PlayerSpeed;
                        if (dist <= stopRange)
                        {
                            ai.canMove = false;

                        }
                        else
                        {
                            ai.canMove = true;

                        }
                    }

                }
                else if (dist > lostRange)
                {

                    if (target != null && ai != null)
                    {
                        ai.destination = target.position;
                        ai.maxSpeed = CastleSpeed;

                    }


                }
                if (ai.canMove)
                {
                    anim.SetBool("WalkingHor", true);
                }
                else
                {
                    anim.SetBool("WalkingHor", false);
                }
                if (target != null && ai != null)
                {
                    if (ai.destination == target.position)
                    {
                        if (aipath.desiredVelocity.x >= 0.01f)
                        {
                            enemyObject.localScale = new Vector3(1f, 1f, 1f);
                        }
                        else
                        {
                            enemyObject.localScale = new Vector3(-1f, 1f, 1f);
                        }
                    }
                    else if (ai.destination == SecondaryTarget.position)
                    {
                        float distance = SecondaryTarget.position.x - enemyObject.position.x;
                        if (distance >= 0.01f)
                        {
                            enemyObject.localScale = new Vector3(1f, 1f, 1f);
                        }
                        else
                        {
                            enemyObject.localScale = new Vector3(-1f, 1f, 1f);
                        }
                    }

                }
            }
            
            
            
        }
    }
}
