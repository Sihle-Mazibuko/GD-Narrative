using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MusaDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int musaVisits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            musaVisits++;

            if (musaVisits > 1)
            {
                dialogueRunner.StartDialogue("MusaLeaveAlone");
            }
            else
            {
                dialogueRunner.StartDialogue("TalkToMusa");
            }
        }
    }
}
