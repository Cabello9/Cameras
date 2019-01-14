using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float sensitiveY;
    public float clapAngle;
    public GameObject camera;
    public GameObject baseCamera;
    public float speedZoom;

    private float rotY = 0;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        warframeRotation();
	}

    private void inputRotation()
    {
        rotY += Input.GetAxis("Mouse Y") * sensitiveY * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -clapAngle, clapAngle);

        transform.rotation = Quaternion.Euler(-rotY,0f, 0f);
    }

    private void warframeRotation()
    {
        rotY += Input.GetAxis("Mouse Y") * sensitiveY * Time.deltaTime;
        rotY = Mathf.Clamp(rotY, -clapAngle, clapAngle);
        transform.rotation = Quaternion.Euler(-rotY, 0f, 0f);

        Debug.Log(rotY+"    "+ Input.GetAxis("Mouse Y"));

        if (Input.GetAxis("Mouse Y") > 0.1 && rotY > 0 && rotY < 60)
        {
            float speed = speedZoom * Time.deltaTime;
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, baseCamera.transform.position, speed);
        }
        else if(Input.GetAxis("Mouse Y") < 0.1 && rotY < 0 && rotY > -60)
        {
            float speed = speedZoom * Time.deltaTime;
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, baseCamera.transform.position, -speed);
        }
    }
}
