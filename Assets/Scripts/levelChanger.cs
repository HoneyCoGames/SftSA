using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(PauseMenu.transition == true) {
            FadeLevel();
        }
    }

    public void FadeLevel() {
        animator.SetTrigger("fadingOut");
    }
}
