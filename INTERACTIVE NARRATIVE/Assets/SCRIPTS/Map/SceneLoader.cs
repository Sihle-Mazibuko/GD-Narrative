using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneLoader : MonoBehaviour
{
    // The name of the scene to load
    public string sceneName;

    public void GoNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
