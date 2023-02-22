using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialogue dialogue;
    public GameObject dialogueCanvas;
    [SerializeField] private DialogueManager dialmanager;
    public void TriggerDialogue()
    {
        dialogueCanvas.SetActive(true);
        dialmanager.StartDialogue(dialogue);
    }
}
