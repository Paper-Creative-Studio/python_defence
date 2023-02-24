using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject main_Canvas;
    public TMP_Text convotext;
    public Image markAvatar;
    public Image npcAvatar;
    public GameObject dialogueCanvas;
    public GameObject npc;
    
    public GameObject player;
    private Queue<string> sentences= new Queue<string>();
    private Queue<Sprite> avatars= new Queue<Sprite>();
    public PythonGame npcscript;
    private movement playermove;
    private Attacking playerattack;
    private string aftermath;
    private void Start()
    {
        //npcscript = npc.GetComponent<PythonGame>();
        playermove = player.GetComponent<movement>();
        playerattack = player.GetComponent<Attacking>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        
        main_Canvas.SetActive(false);
        npcscript.talking = true;
        playermove.moving = false;
        playerattack.canAttack = false;
        
        sentences.Clear();
        avatars.Clear();
        foreach(Array2DForDialogue dialarray in dialogue.speech)
        {
            avatars.Enqueue(dialarray.avatar);
            sentences.Enqueue(dialarray.sentence);
        }
        aftermath = dialogue.aftermath;
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count ==0) 
        {
            dialogueCanvas.SetActive(false);
            avatars.Clear();
            sentences.Clear();
            npcscript.talking = false;
            playermove.moving = true;
            playerattack.canAttack = true;
            if (aftermath== "Python")
            {
                npcscript.LaunchPython();
            }
            else
            {
                main_Canvas.SetActive(true);
            }
            
            return;
        }
        string sentence = sentences.Dequeue();
        Sprite avatar = avatars.Dequeue();
        if(avatar.name == "mark_avatar")
        {
            markAvatar.enabled = true;
            npcAvatar.enabled = false;
            markAvatar.sprite= avatar;
            convotext.alignment = TextAlignmentOptions.MidlineLeft;

        }
        else
        {
            markAvatar.enabled = false;
            npcAvatar.enabled = true;
            npcAvatar.sprite= avatar;
            convotext.alignment = TextAlignmentOptions.MidlineRight;
        }
        convotext.text = sentence;
    }

}
