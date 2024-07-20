using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private Camera cam;
    private float camHeight;
    private float camWidth;
    public float YClampOffsetFactorMax;
    public float YClampOffsetFactorMin;

    void Start()
    {
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    public Vector3 GetClampedPosition(Vector3 targetPosition, float margin = 0.5f)
    {
        float halfCamWidth = camWidth / 2f;
        float halfCamHeight = camHeight / 2f;

        float minX = cam.transform.position.x - halfCamWidth + margin;
        float maxX = cam.transform.position.x + halfCamWidth - margin;
        float minY = cam.transform.position.y - halfCamHeight + margin+YClampOffsetFactorMin;
        float maxY = minY + (halfCamHeight*2)*YClampOffsetFactorMax;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        return targetPosition;
    }
}