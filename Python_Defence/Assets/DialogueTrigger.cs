using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Dialogue> dialogues = new List<Dialogue>();
    public int Ksiadzindex = 0;
    public int Gornikindex = 0;
    public int Kowalindex = 0;
    public int Stajniaindex = 0;
    public int Archerindex = 0;
    public int Farmerindex = 0;
    int index = 0;
    public GameObject dialogueCanvas;
    [SerializeField] private DialogueManager dialmanager;
    private PythonGame pg;
    private TradeNPC tn;
    private void Start()
    {
        pg = GetComponent<PythonGame>();
        tn = GetComponent<TradeNPC>();
        if (gameObject.name == "Ksiadz")
            index = Ksiadzindex;
        if (gameObject.name == "Gornik")
            index = Gornikindex;
        if (gameObject.name == "Kowal")
            index = Kowalindex;
        if (gameObject.name == "TypOdStajni")
            index = Stajniaindex;
        if (gameObject.name == "ArcherZbrojowania")
            index = Archerindex;
        if (gameObject.name == "Farmer")
            index = Farmerindex;
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
