using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class LindaDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int lindaVisits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lindaVisits++;

            if (lindaVisits > 1)
            {
                dialogueRunner.StartDialogue("LindaLeaveAlone");
            }
            else
            {
                dialogueRunner.StartDialogue("TalkToLinda");
            }
        }
    }
}
