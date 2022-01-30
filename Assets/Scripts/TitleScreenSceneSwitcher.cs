using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleScreenSceneSwitcher : MonoBehaviour
{
    public string nextScene;

    void Update()
    {
        // If this key is pressed and released...
        if (Input.GetKeyUp(KeyCode.S) == true)
        {
            // Load next scene
            SceneManager.LoadScene(nextScene);
        }
    }
}
