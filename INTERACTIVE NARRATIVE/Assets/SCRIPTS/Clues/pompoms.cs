using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class pompoms : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int pompomsVisits = 0;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pompomsVisits++;

            if (pompomsVisits > 1)
            {
                dialogueRunner.StartDialogue("StartInvestigation10");
            }
            else
            {
                dialogueRunner.StartDialogue("ExaminePompoms");
            }
        }
    }
}
