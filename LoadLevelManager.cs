using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//load the next scene in the build settings
public class LoadLevelManager : MonoBehaviour {

    public void LoadNextScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void Quit() {
        Application.Quit();
    }
}
