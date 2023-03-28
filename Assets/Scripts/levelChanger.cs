using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManager;

public class levelChanger : MonoBehaviour
{

    public Animator animator;

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
        }
        else if(MainMenu.changeToLevel == 1) {
            FadeToLevel("Sky1");
        }
    }

    public void FadeToLevel(string level) {
        //Scene sc = SceneManager.GetSceneByName(level);
        MainMenu.changeToLevel = -1;
        animator.Play("fadeOut");
        SceneManager.LoadScene(level);
    }
}
