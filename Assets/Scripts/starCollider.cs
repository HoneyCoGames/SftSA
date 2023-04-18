using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starCollider : MonoBehaviour
{
 

    private void onTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided!");
    }
    private void onTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Still colliding...");
    }
    private void onTriggerExit2D(Collider2D collision)
    {
        Debug.Log("No longer colliding!");
    }


}
