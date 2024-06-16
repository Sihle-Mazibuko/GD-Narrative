using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class XolaDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    private int xolaVisits = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            xolaVisits++;

            if (xolaVisits > 1)
            {
                dialogueRunner.StartDialogue("XolaLeaveAlone");
            }
            else
            {
                dialogueRunner.StartDialogue("GoToXola");
            }
        }
    }
}
