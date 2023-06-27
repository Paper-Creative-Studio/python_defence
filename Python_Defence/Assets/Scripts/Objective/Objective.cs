using UnityEngine;

namespace PythonDefence.Objective
{
    [System.Serializable]
    public class Objective
    {
        public string internalTitle;
        public string Title;
        [TextArea] public string CoZrobic;
        public Transform placeToDo;
    
   
    }
}
