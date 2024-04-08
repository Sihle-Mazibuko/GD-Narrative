using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CluePopUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI popUpTxt;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowPopUp(string message)
    {
        popUpTxt.text = message;
        gameObject.SetActive(true);
        Invoke("HidePopUp", 2f);

        Debug.Log("Pop-up shown: " + message);

    }

    void HidePopUp()
    {
        gameObject.SetActive(false);

        Debug.Log("Pop-up hidden");
    }
}
