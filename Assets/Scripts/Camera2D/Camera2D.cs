using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Camera camera;
    public List<GameObject> actors;

    private float xPos = 0, yPos = 0;
    private float xMin = 0, xMax = 0, yMin = 0, yMax = 0;
    private float sumXMin, sumXMax, sumYMin, sumYMax;
    private float halfCameraWidth;

    void Start()
    {
        for(int i = 0; i < actors.Count; i++)
        {
            xPos += actors[i].transform.position.x;
            yPos += actors[i].transform.position.y;
        }

        xPos /= actors.Count;
        yPos /= actors.Count;

        halfCameraWidth = (2f * camera.orthographicSize * camera.aspect) / 2;

        camera.transform.position = new Vector3(xPos, yPos, camera.transform.position.z);
            
    }

    void Update()
    {
        actorsHandle();
        calculateCameraSize();
    }

    private void actorsHandle()
    {
        for (int i = 0; i < actors.Count; i++)
        {
            xPos += actors[i].transform.position.x;
            yPos += actors[i].transform.position.y;
        }

        xPos /= actors.Count;
        yPos /= actors.Count;

        camera.transform.position = new Vector3(xPos, yPos, camera.transform.position.z);
    }

    private void calculateCameraSize()
    {
        xMin = actors[0].transform.position.x;
        xMax = actors[0].transform.position.x;
        yMin = actors[0].transform.position.y;
        yMax = actors[0].transform.position.y;

        for (int i=1;i < actors.Count; i++)
        {
            if (xMin > actors[i].transform.position.x)
                xMin = actors[i].transform.position.x;

            if (xMax < actors[i].transform.position.x)
                xMax = actors[i].transform.position.x;

            if (yMin > actors[i].transform.position.y)
                yMin = actors[i].transform.position.y;

            if (yMax < actors[i].transform.position.y)
                yMax = actors[i].transform.position.y;
        }

        sumXMin = Mathf.Abs(camera.transform.position.x - xMin);
        sumXMax = Mathf.Abs(camera.transform.position.x - xMax);
        sumYMin = Mathf.Abs(camera.transform.position.y - yMin);
        sumYMax = Mathf.Abs(camera.transform.position.y - yMax);

        float maxCameraSizeY =  Mathf.Max(sumYMin, sumYMax);
        float maxCameraSizeX = Mathf.Max(sumXMin, sumXMax);
        float xSizeToYSize = (maxCameraSizeX * 5) / halfCameraWidth;
        float compareSize = xSizeToYSize > maxCameraSizeY ? xSizeToYSize : maxCameraSizeY;
        compareSize += 1;
       
        camera.orthographicSize = compareSize > 5 ? compareSize : 5;

    }
}
