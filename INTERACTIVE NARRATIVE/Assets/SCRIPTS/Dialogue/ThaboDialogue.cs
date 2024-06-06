using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ThaboDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int thaboVisits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            thaboVisits++;

            if (thaboVisits > 1)
            {
                dialogueRunner.StartDialogue("ThaboLeaveAlone");
            }
            else
            {
                dialogueRunner.StartDialogue("TalkToThabo");
            }
        }
    }
}
