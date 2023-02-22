using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Dialogue
{
    public string npcName;
    
    public Array2DForDialogue[] speech;
    
}
[System.Serializable]
public class Array2DForDialogue
{
    public Sprite avatar;
    [TextArea]
    public string sentence;
}
