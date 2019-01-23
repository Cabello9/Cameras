using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float xSpeed, ySpeed;
    public int xClipPos,xClipNeg, yClipPos,yClipNeg;

    private bool back = false;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * xSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * ySpeed * Time.deltaTime);

        if(transform.position.x > xClipPos)
        {
            xSpeed *= -1;
        }

        if(transform.position.x < xClipNeg)
        {
            xSpeed *= -1;
        }

        if (transform.position.y > yClipPos)
        {
            ySpeed *= -1;
        }

        if (transform.position.y < yClipNeg)
        {
            ySpeed *= -1;
        }
    }
}
