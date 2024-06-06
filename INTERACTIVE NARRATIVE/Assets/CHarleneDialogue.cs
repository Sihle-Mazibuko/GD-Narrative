using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CHarleneDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int charleneVisits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            charleneVisits++;

            if (charleneVisits > 1)
            {
                dialogueRunner.StartDialogue("CharleneLeaveAlone");
            }
            else
            {
                dialogueRunner.StartDialogue("TalkToCharlene");
            }
        }
    }
}
