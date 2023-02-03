using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
        {
            coll.collider.enabled = true;
            // If the Collider2D component is enabled on the collided object
            if (coll.collider == true)
            {
                // Disables the Collider2D component
                // coll.collider.enabled = false;
            }
        }


}
