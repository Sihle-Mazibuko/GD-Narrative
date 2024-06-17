using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationDialogue : MonoBehaviour
{
    public static ConfirmationDialogue Instance;

    [SerializeField]  TextMeshProUGUI confirmationText;
    [SerializeField]  Button yesButton;
    [SerializeField]  Button noButton;

     Clue clueToCollect;
    GameObject clueGameObj;
    

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowDialogue(Clue clue, GameObject clueObj)
    {
        clueToCollect = clue;
        clueGameObj = clueObj;
        confirmationText.text = $"Do you want to collect this clue: a {clue.clueName}?";
        gameObject.SetActive(true);
    }

    public void OnYesButtonClicked()
    {
        GameManagment.Instance.AddClue(clueToCollect);
        InventoryUI.Instance.UpdateInventory();
        Destroy(clueGameObj);
        gameObject.SetActive(false);
    }

    public void OnNoButtonClicked()
    {
        gameObject.SetActive(false);
    }
}