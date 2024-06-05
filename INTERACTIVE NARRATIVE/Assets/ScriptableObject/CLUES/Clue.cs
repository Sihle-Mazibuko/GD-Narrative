using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Clue", menuName = "Clue")]

public class Clue : ScriptableObject
{
    public string clueName;
    public string shortDescription;
    public string longDescription;
    public Sprite clueImage;


}
