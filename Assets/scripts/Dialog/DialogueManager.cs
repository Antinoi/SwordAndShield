using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

  

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public bool dialogueend = false;

    public float typingSpeed = 3f;

    public Animator animator;

 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();


    }

    public void StartDialogue(Dialogue dialogue)
    {

        

        isDialogueActive = true;

       

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

       

        DialogueLine currentLine = lines.Dequeue();



        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        if (characterName.text == "Люцианна Кассар, Императрица Аурельская")
        {
            animator.Play("ShowUp");
        }
        else if(characterName.text == "Тиберий Кассар, Щит Империи" || characterName.text == "Каэль Вальтерис, Меч Империи")
        {
            animator.Play("Partner");
         
        }else{

            animator.Play("Neit");

        }

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialogue()
    {



       
        animator.Play("Close");
        lines.Clear();
        isDialogueActive = false;
        GameManager.Instance.EnemyKilled();



    }


}
