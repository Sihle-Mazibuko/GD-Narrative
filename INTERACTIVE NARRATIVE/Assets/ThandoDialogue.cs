using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ThandoDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int thandoVisits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            thandoVisits++;

            if (thandoVisits > 1)
            {
                dialogueRunner.StartDialogue("ThandoLeaveAlone");
            }
            else
            {
                dialogueRunner.StartDialogue("TalkToThando");
            }
        }
    }
}