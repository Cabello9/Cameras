using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndZoomBase : MonoBehaviour
{
    public float speedRotX;
    private float rotX = 0;

    void Update()
    {
        inputHandle();
    }

    private void inputHandle()
    {
        rotX = Input.GetAxis("Mouse X") * speedRotX * Time.deltaTime;
        transform.RotateAround(transform.position, Vector3.up, rotX);
    }
}
