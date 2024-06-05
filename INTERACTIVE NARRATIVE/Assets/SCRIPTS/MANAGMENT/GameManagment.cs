using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    public static GameManagment Instance;

    public List<Clue> collectedClues = new List<Clue>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddClue(Clue clue)
    {
        if (!collectedClues.Contains(clue))
        {
            collectedClues.Add(clue);
        }
    }
}