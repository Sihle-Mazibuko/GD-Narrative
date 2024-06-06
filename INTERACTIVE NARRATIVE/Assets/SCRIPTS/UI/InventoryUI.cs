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


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            inventoryPanelUI.SetActive(false);
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

        if (GameManagment.Instance == null || GameManagment.Instance.collectedClues == null || GameManagment.Instance.collectedClues.Count == 0)
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
            TextMeshProUGUI clueNameText = clueCard.transform.Find("ClueName").GetComponent<TextMeshProUGUI>();
            Image clueImage = clueCard.transform.Find("ClueImage").GetComponent<Image>();
        }
    }

    public void ToggleInventory()
    {
        bool isActive = inventoryPanelUI.activeSelf;
        inventoryPanelUI.SetActive(!isActive);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            ToggleInventory();
        }
    }
}