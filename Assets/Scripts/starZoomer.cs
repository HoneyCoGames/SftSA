using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starZoomer : MonoBehaviour
{
    bool canZoomIn = true;
    bool canZoomOut = true;
    float scrollVal = 0;
    Vector2 vec;
    Vector2 vec2;

    // Use Lerp for linear and SmoothDamp for smooth
        // if (useLerp)
        // {
        //     myTransform.localScale = Vector3.Lerp(myTransform.localScale, target, Time.deltaTime * lerpSpeed);
        // }
        // else
        // {
        //     myTransform.localScale = Vector3.SmoothDamp(myTransform.localScale, target, ref velocity, smoothTime);
        // }

    // Update is called once per frame
    void Update()
    {

        if(transform.localScale.x < 0.5)
        {
            canZoomOut = false;
        }
        else {
            canZoomOut = true;
        }
        if(transform.localScale.x > 3)
        {
            canZoomIn = false;
        }
        else {
            canZoomIn = true;
        }

        vec = Input.mouseScrollDelta;
        scrollVal = vec.y;

        if(scrollVal > 0 && canZoomIn)
        {
            zoomIn();
        }
        else if(scrollVal < 0 && canZoomOut)
        {
            zoomOut();
        }
    }

    void zoomIn() {
        Vector3 inc = transform.localScale;
        inc.x += (Time.deltaTime * 10);
        inc.y += (Time.deltaTime * 10);
        transform.localScale = inc;
    }

    void zoomOut() {
        Vector3 inc = transform.localScale;
        inc.x -= (Time.deltaTime * 10);
        inc.y -= (Time.deltaTime * 10);
        transform.localScale = inc;
    }

}
