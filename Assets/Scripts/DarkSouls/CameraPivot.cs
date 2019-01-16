using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public float speedRotY;
    public float clampY;
    private float rotY = 0;

    void Update()
    {
        inputHandle();
    }

    private void inputHandle()
    {
        rotY += Input.GetAxis("Mouse Y") * speedRotY * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -clampY, clampY);

        if (rotY < -clampY + 1 || rotY > clampY - 1)
        {
            FindObjectOfType<ZoomInOut>().clamp = true;
        }
        else
        {
            FindObjectOfType<ZoomInOut>().clamp = false;
        }
            

        transform.localEulerAngles = new Vector3(-rotY, 0, 0);
    }
}
