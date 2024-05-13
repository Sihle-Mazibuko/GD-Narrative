using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusaProfile : MonoBehaviour
{
    public GameObject musaProfile;

    public void Start()
    {
        musaProfile.SetActive(false);
    }

    public void OnMouseOver()
    {
        musaProfile.SetActive(true);
    }

    public void OnMouseExit()
    {
        musaProfile.SetActive(false);
    }
}
