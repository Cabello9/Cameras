using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotation : MonoBehaviour
{
    public float sensitiveX;
    public GameObject camera;

    private float rotX = 0;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        warframeRotation();

	}

    private void inputRotation()
    {
        rotX = Input.GetAxis("Mouse X") * sensitiveX;
        transform.Rotate(0f, rotX, 0f);
    }

    private void warframeRotation()
    {
        rotX = Input.GetAxis("Mouse X") * sensitiveX * Time.deltaTime;
        transform.Rotate(0f, rotX, 0f);

        Debug.Log(rotX+"    "+ Input.GetAxis("Mouse X"));

        /*if (Input.GetAxis("Mouse X") > 0.1)
        {
            camera.Translate(Vector3.forward * 1 * Time.deltaTime);
        }
        else if(Input.GetAxis("Mouse X") < 0.1)
        {
        
        }*/
    }
}
