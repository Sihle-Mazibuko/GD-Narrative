using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThandoProfile : MonoBehaviour
{
    public GameObject thandoProfile;

    public void Start()
    {
        thandoProfile.SetActive(false);
    }

    public void OnMouseOver()
    {
        thandoProfile.SetActive(true);
    }

    public void OnMouseExit()
    {
        thandoProfile.SetActive(false);
    }
}
