using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{

    public AnimationCurve animationCurve;
    public float speedRot;
    public Transform target;
    public bool clamp;

    private float rotY = 0;
    private int controlDirection;

    void Start()
    {
        
    }

    void Update()
    {
        zoomHandle();
    }

    private void zoomHandle()
    {
        if(!clamp)
        {
            rotY = Input.GetAxis("Mouse Y") * speedRot * Time.deltaTime;
            rotY = Mathf.Clamp(rotY, -1, 1);

            Debug.Log(rotY + "    " + animationCurve.Evaluate(rotY));

            if (rotY < -0.01f)
            {
                controlDirection = -1;
            }
            else if (rotY > 0.01f)
            {
                controlDirection = 1;
            }

            transform.Translate(target.transform.forward * animationCurve.Evaluate(rotY) * controlDirection);
        }
    
    }
}
