using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LindaProfile : MonoBehaviour
{
    public GameObject lindaProfile;

    public void Start()
    {
        lindaProfile.SetActive(false);
    }

    public void OnMouseOver()
    {
        lindaProfile.SetActive(true);
    }

    public void OnMouseExit()
    {
        lindaProfile.SetActive(false);
    }
}
