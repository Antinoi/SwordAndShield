using System.Collections;
using System.Collections.Generic;
using UnityEngine;






[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}



public class DialogeTrigger : MonoBehaviour
{

   

    public Dialogue dialogue;

    public void Start()
    {
        
        DialogueManager.Instance.StartDialogue(dialogue);
       
    }

   
}
