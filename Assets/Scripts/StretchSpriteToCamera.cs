using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StretchSpriteToCamera : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        ResizeSpriteToCamera();
    }

    void ResizeSpriteToCamera()
    {

        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenAspect;


        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;


        float spriteAspect = spriteSize.x / spriteSize.y;
        float newWidth, newHeight;

        if (screenAspect >= spriteAspect)
        {

            newHeight = cameraHeight;
            newWidth = cameraHeight * spriteAspect;
            newHeight /= screenAspect;
        }
        else
        {

            newWidth = cameraWidth;
            newHeight = cameraWidth / spriteAspect;
            newHeight /= screenAspect;
        }


        spriteRenderer.size = new Vector2(newWidth, newHeight);
    }

}