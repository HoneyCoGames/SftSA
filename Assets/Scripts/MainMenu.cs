using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static int changeToLevel = -1;
    // 0 = main

    public void LoadLevel1() {
        Debug.Log("[DEBUG MSG] Loading Level 1");
        // Change scene here
        //SceneManager.LoadScene("Sky1");
        changeToLevel = 1;
    }
    public void LoadLevel2() {
        Debug.Log("[DEBUG MSG] Loading Level 2");
        // Change scene here
        SceneManager.LoadScene("Sky2");
        changeToLevel = 2;
    }
}