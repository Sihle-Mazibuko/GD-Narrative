using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThaboProfile : MonoBehaviour
{
    public GameObject thaboProfile;

    public void Start()
    {
        thaboProfile.SetActive(false);
    }

    public void OnMouseOver()
    {
        thaboProfile.SetActive(true);
    }

    public void OnMouseExit()
    {
        thaboProfile.SetActive(false);
    }
}
