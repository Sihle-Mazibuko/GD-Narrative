using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalProfile : MonoBehaviour
{
    public GameObject principalProfile;

    public void Start()
    {
        principalProfile.SetActive(false);
    }

    public void OnMouseOver()
    {
        principalProfile.SetActive(true);
    }

    public void OnMouseExit()
    {
        principalProfile.SetActive(false);
    }
}
