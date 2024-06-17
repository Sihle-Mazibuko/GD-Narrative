using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set; }

    [SerializeField] private GameObject clueCardPrefab;
    [SerializeField] private Transform gridTransform;
    [SerializeField] private GameObject inventoryPanelUI;
    [SerializeField] private GameObject detailedCluePanel;
    [SerializeField] private Image detailedClueImage;
    [SerializeField] private TextMeshProUGUI detailedClueName;
    [SerializeField] private TextMeshProUGUI detailedClueDescription;
    [SerializeField] private TextMeshProUGUI shortClueDescription;
    [SerializeField] private Button closeButton;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            inventoryPanelUI.SetActive(false);
            detailedCluePanel.SetActive(false);
            closeButton.onClick.AddListener(CloseDetailedView);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        if (gridTransform == null || GameManagment.Instance == null)
        {
            return;
        }

        foreach (Transform child in gridTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (Clue clue in GameManagment.Instance.collectedClues)
        {
            GameObject clueCard = Instantiate(clueCardPrefab, gridTransform);
            clueCard.transform.Find("ClueName").GetComponent<TextMeshProUGUI>().text = clue.clueName;
            clueCard.transform.Find("ClueImage").GetComponent<Image>().sprite = clue.clueImage;
            clueCard.GetComponent<Button>().onClick.AddListener(() => ShowDetailedView(clue));
        }
    }

    public void ToggleInventory()
    {
        bool isActive = inventoryPanelUI.activeSelf;
        inventoryPanelUI.SetActive(!isActive);
    }


    private void ShowDetailedView(Clue clue)
    {
        detailedClueName.text = clue.clueName;
        detailedClueImage.sprite = clue.clueImage;
        detailedClueDescription.text = clue.longDescription;
        detailedClueDescription.text = clue.shortDescription;
        detailedCluePanel.SetActive(true);
    }

    private void CloseDetailedView()
    {
        detailedCluePanel.SetActive(false);
    }
}
