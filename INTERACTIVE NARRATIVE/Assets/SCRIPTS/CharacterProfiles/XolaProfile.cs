using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolaProfile : MonoBehaviour
{
    public GameObject xolaProfile;

    public void Start()
    {
        xolaProfile.SetActive(false);
    }

    public void OnMouseOver()
    {
        xolaProfile.SetActive(true);
    }

    public void OnMouseExit()
    {
        xolaProfile.SetActive(false);
    }
}
