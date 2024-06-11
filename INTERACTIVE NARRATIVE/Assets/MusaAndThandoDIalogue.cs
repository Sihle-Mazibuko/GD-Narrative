using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MusaAndThandoDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int MusaAndThandoVisits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MusaAndThandoVisits++;

            if (MusaAndThandoVisits > 1)
            {
                dialogueRunner.StartDialogue("MusaLeaveAlone");
            }
            else
            {
                dialogueRunner.StartDialogue("TalkToMusaAndThando");
            }
        }
    }
}