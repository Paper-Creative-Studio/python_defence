using UnityEngine;

namespace PythonDefence.Dialogue
{
    [System.Serializable]
    public class Dialogue
    {
        public string npcName;
    
        public Array2DForDialogue[] speech;
        public string aftermath;
    }
    [System.Serializable]
    public class Array2DForDialogue
    {
        public Sprite avatar;
        [TextArea]
        public string sentence;
    }
}