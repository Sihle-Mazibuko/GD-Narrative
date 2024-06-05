using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationDialogue : MonoBehaviour
{
    public static ConfirmationDialogue Instance;

    [SerializeField] private TextMeshProUGUI confirmationText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    private Clue clueToCollect;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void ShowDialogue(Clue clue)
    {
        clueToCollect = clue;
        confirmationText.text = $"Do you want to collect this clue: a {clue.clueName}?";
        gameObject.SetActive(true);
    }

    public void OnYesButtonClicked()
    {
        GameManagment.Instance.AddClue(clueToCollect);
        InventoryUI.Instance.UpdateInventory();
        gameObject.SetActive(false);
    }

    public void OnNoButtonClicked()
    {
        gameObject.SetActive(false);
    }
}