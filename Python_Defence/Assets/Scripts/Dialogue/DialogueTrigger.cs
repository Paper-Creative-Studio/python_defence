using System.Collections.Generic;
using PythonDefence.NPC;
using PythonDefence.Compiler;
using UnityEngine;

namespace PythonDefence.Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<Dialogue> dialogues = new List<Dialogue>();
        public int index = 0;
        public GameObject dialogueCanvas;
        [SerializeField] private DialogueManager dialmanager;
        private NPCProperties pg;
        private TradeNPC tn;
        private void Start()
        {
            pg = GetComponent<NPCProperties>();
            tn = GetComponent<TradeNPC>();
        
        }
        private void Update()
        {
            //    Debug.Log(gameObject.name + " " + index);
        }
        public void TriggerDialogue()
        {
            dialogueCanvas.SetActive(true);
            dialmanager.npcscript = pg;
            dialmanager.tradescript = tn;
            dialmanager.StartDialogue(dialogues[index]);
        }
    }
}
