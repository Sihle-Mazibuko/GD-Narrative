using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class tie : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int principalVisits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            principalVisits++;

            if (principalVisits > 1)
            {
                dialogueRunner.StartDialogue("LeaveTie");
            }
            else
            {
                dialogueRunner.StartDialogue("ExamineTie");
            }
        }
    }
}
