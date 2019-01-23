using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public Transform baseCamera;
    public LayerMask layerMask;
    public GameObject yMovementScript;
    public GameObject xMovementScript;
    public Transform initialPos;

    private float x, y, z = 0;
    private float zBack = 0;
    private List<Vector3> clipPoints;
    private List<Vector3> desiredPoints;
    private float limits;
    

    void Start()
    {
        y = Mathf.Tan(Camera.main.fieldOfView / 2 * Mathf.Deg2Rad) * Camera.main.nearClipPlane;
        x = y * Camera.main.aspect;
        clipPoints = new List<Vector3>();
        desiredPoints = new List<Vector3>();
        
    }

    void FixedUpdate()
    {
        updateCameraClipPoints();
        Debug.DrawRay(clipPoints[0], transform.forward * 5f, Color.green);
        Debug.DrawRay(clipPoints[1], transform.forward * 5f, Color.green);
        Debug.DrawRay(clipPoints[2], transform.forward * 5f, Color.green);
        Debug.DrawRay(clipPoints[3], transform.forward * 5f, Color.green);
        Debug.DrawRay(clipPoints[0], transform.TransformDirection(Vector3.back) * 1f, Color.red);
        Debug.DrawRay(clipPoints[1], transform.TransformDirection(Vector3.back) * 1f, Color.red);
        Debug.DrawRay(clipPoints[2], transform.TransformDirection(Vector3.back) * 1f, Color.red);
        Debug.DrawRay(clipPoints[3], transform.TransformDirection(Vector3.back) * 1f, Color.red);
        moveForwardCameraDependingCollision();
    }

    private void updateCameraClipPoints()
    {
        y = Mathf.Tan(Camera.main.fieldOfView / 2 * Mathf.Deg2Rad) * Camera.main.nearClipPlane;
        x = y * Camera.main.aspect;

        clipPoints.Insert(0, transform.rotation * new Vector3(x, y, z) + transform.position); //Top right
        clipPoints.Insert(1, transform.rotation * new Vector3(-x, y, z) + transform.position); //Top Left
        clipPoints.Insert(2, transform.rotation * new Vector3(-x, -y, z) + transform.position); //Bot left
        clipPoints.Insert(3, transform.rotation * new Vector3(x, -y, z) + transform.position); //Bot right

        desiredPoints.Insert(0, transform.rotation * new Vector3(x, y, zBack) + transform.position); //Top right
        desiredPoints.Insert(1, transform.rotation * new Vector3(-x, y, zBack) + transform.position); //Top Left
        desiredPoints.Insert(2, transform.rotation * new Vector3(-x, -y, zBack) + transform.position); //Bot left
        desiredPoints.Insert(3, transform.rotation * new Vector3(x, -y, zBack) + transform.position); //Bot right
    }

    private bool CollisionDetectedAtClipPoints()
    {

        for(int i = 0; i < 4; i++){
            if(Physics.Raycast(clipPoints[i], transform.TransformDirection(Vector3.forward), 5f,layerMask))
            {
                return true; 
            }
        }
        xMovementScript.GetComponent<RotateAndZoomBase>().enabled = true;
        yMovementScript.GetComponent<CameraPivot>().enabled = true;
        return false;
    }

    private bool CollisionDetectedAtClipPointsBack()
    {

        for (int i = 0; i < 4; i++)
        {
            if (Physics.Raycast(clipPoints[i], transform.TransformDirection(Vector3.back), 1f, layerMask))
            {
                return true;
            }
        }

        xMovementScript.GetComponent<RotateAndZoomBase>().enabled = true;
        yMovementScript.GetComponent<CameraPivot>().enabled = true;
        return false;
    }

    private void moveForwardCameraDependingCollision()
    {
        //Debug.Log(CollisionDetectedAtClipPoints());
        if (CollisionDetectedAtClipPoints())
        {
            Debug.Log("ENTRO VERDE");
            limits += 0.8f * Time.deltaTime; 
            limits = Mathf.Clamp(limits, 0, 0.8f);
            transform.position = Vector3.Lerp(initialPos.position, baseCamera.transform.position, limits);
        }
        else
        {
            if (!CollisionDetectedAtClipPointsBack())
            {
                Debug.Log("ENTRO ROJO");
                limits -= 0.8f * Time.deltaTime;
                limits = Mathf.Clamp(limits, 0, 0.8f);
                transform.position = Vector3.Lerp(initialPos.position, baseCamera.transform.position, limits);
            }
        }
    }
}
