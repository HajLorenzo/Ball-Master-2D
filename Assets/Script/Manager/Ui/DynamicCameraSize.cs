using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class DynamicCameraSize : MonoBehaviour
{
    public float sceneWidth = 10;
    Camera camera;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        
    }
    private void Start()
    {
        float unitsPerPixel = sceneWidth / Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
        camera.orthographicSize = desiredHalfHeight;
    }
}
