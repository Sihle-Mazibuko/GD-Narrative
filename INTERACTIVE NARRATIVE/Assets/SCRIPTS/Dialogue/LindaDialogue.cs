using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LindaDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    bool collidedWithLinda = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collidedWithLinda = true;

            dialogueRunner.dialogue.variableStorage.SetValue("$collidedWithLinda", collidedWithLinda.ToString());

            dialogueRunner.StartDialogue("TalkToLinda"); 
        }
    }
}
