using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Dialogue> dialogues = new List<Dialogue>();
    public int index = 0;
    public GameObject dialogueCanvas;
    [SerializeField] private DialogueManager dialmanager;
    private PythonGame pg;
    private TradeNPC tn;
    private void Start()
    {
        pg = GetComponent<PythonGame>();
        tn = GetComponent<TradeNPC>();
    }
    private void Update()
    {
        //Debug.Log(gameObject.name + " " + index);
    }
    public void TriggerDialogue()
    {
        dialogueCanvas.SetActive(true);
        dialmanager.npcscript = pg;
        dialmanager.tradescript = tn;
        dialmanager.StartDialogue(dialogues[index]);
    }
}
