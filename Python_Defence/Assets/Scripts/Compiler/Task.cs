using UnityEngine;
using UnityEngine.Events;

namespace PythonDefence.Compiler
{
    [System.Serializable]
    public class Task
    {
    
        [TextArea] public string Polecenie;
        [TextArea]public string output;
        [TextArea]public string secondaryoutput;
    
        [TextArea]public string stale;
        [TextArea]public string addition;
        [TextArea]public string condition;
        public UnityEvent onSuccesful;
    }
}
