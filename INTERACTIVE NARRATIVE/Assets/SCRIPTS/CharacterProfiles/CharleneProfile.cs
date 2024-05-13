using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharleneProfile : MonoBehaviour
{
    public GameObject charleneProfile;

    public void Start()
    {
        charleneProfile.SetActive(false);
    }

    public void OnMouseOver()
    {
        charleneProfile.SetActive(true);
    }

    public void OnMouseExit()
    {
        charleneProfile.SetActive(false);
    }
}
