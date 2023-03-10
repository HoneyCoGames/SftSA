using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManager;

public class levelChanger : MonoBehaviour
{

    public Animator animator;
    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainMenu.changeToLevel == 0)
        {
            FadeToLevel("MainMenu");
            MainMenu.changeToLevel = -1;
        }
        else if(MainMenu.changeToLevel == 0) {
            FadeToLevel("Sky1");
            MainMenu.changeToLevel = -1;
        }
    }

    public void FadeToLevel(string level) {
        //Scene sc = SceneManager.GetSceneByName(level);
        Debug.Log("Fading Out!");
        SceneManager.LoadScene(level);
        animator.SetTrigger("fadingOut");
    }
}
