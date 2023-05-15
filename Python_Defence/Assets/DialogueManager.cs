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
    [SerializeField] private DialogueTrigger farmerdialtrig;
    public PythonGame npcscript;
    public TradeNPC tradescript;
    private movement playermove;
    private Attacking playerattack;
    private string aftermath;
    [SerializeField] private Eq eqscript;
    [SerializeField] private farmamanagement farma;
    private void Start()
    {
        //npcscript = npc.GetComponent<PythonGame>();
        playermove = player.GetComponent<movement>();
        playerattack = player.GetComponent<Attacking>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        
        main_Canvas.SetActive(false);
        if (npcscript != null) 
        {
            npcscript.talking = true;
        }
        playermove.moving = false;
        playermove.rb.velocity = Vector2.zero;
        playermove.DisableAnimations();
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
            if (npcscript != null)
                npcscript.talking = false;
            playermove.moving = true;
            playerattack.canAttack = true;
            if (aftermath== "Python")
            {
                npcscript.LaunchPython();
            }
            else if (aftermath == "Python")
            {
                tradescript.StartShop();
            }
            else if(aftermath == "Shop")
            {
                tradescript.StartShop();
            }
            else if (aftermath == "Harvest")
            {
                eqscript.giveHajs(10);
                eqscript.zaznaczHajs();
                main_Canvas.SetActive(true);
                farmerdialtrig.Farmerindex = 1;
                farma.Zbierz();
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
            npcAvatar.SetNativeSize();
            convotext.alignment = TextAlignmentOptions.MidlineRight;
        }
        convotext.text = sentence;
    }

}
