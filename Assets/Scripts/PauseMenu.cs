using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool paused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure game will start with paused = false;
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
    public void LoadMenu() {
        Debug.Log("[DEBUG MSG] Loading Main Menu");
        // Change scene here
        SceneManager.LoadScene("Title");
    }
    public void QuitGame() {
        Debug.Log("[DEBUG MSG] Quitting Game...");
        Application.Quit();
    }

}