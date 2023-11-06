using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3? basePonterPosition = null;

    public float cameraMovementSpeed = 0.05f;

    private int cameraXMin, cameraXMax, cameraZMin, cameraZMax;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera(Vector3 pointerposition)
    {
        if (basePonterPosition.HasValue == false)
        {
            basePonterPosition = pointerposition;
        }

        Vector3 newPosition = pointerposition - basePonterPosition.Value;
        newPosition = new Vector3(newPosition.x, 0, newPosition.y); //mouse-ic stanalu enq x u y
        transform.Translate(newPosition*cameraMovementSpeed);
        LimitPositionInsideCameraBounds();
    }

    private void LimitPositionInsideCameraBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraXMin, cameraXMax),
            0,
            Mathf.Clamp(transform.position.z, cameraZMin, cameraZMax)
        );
        /*Mathf.Clamp(value, min, max)
         The Mathf.Clamp function works as follows:
            If value is less than min, it returns min.
            If value is greater than max, it returns max.
            If value is within the range [min, max], it returns value unchanged.
         It ensures that transform.position.x is clamped within the range defined by cameraXMin and cameraXMax. If transform.position.x is less than cameraXMin, it will be set to cameraXMin, and if it's greater than cameraXMax, it will be set to cameraXMax. If transform.position.x is already within that range, it remains unchanged. This is a common technique for limiting object positions within a specific boundary, such as a camera's visible area in a game.*/
    }

    public void StopCameraMovement()
    {
        basePonterPosition = null;
    }

    public void SetCameraLimits(int cameraXMin, int cameraXMax, int cameraZMin, int cameraZMax)
    {
        this.cameraXMax = cameraXMax;
        this.cameraXMin = cameraXMin;
        this.cameraZMax = cameraZMax;
        this.cameraZMin = cameraZMin;
    }
}
