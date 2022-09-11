using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        RotateCamera();
        zoomCamera();
    }

    void MoveCamera()
    {
        if(Input.GetMouseButton(0))//ÁÂÅ¬¸¯
        {
            transform.Translate(Input.GetAxisRaw("Mouse X") / 10f,
                Input.GetAxisRaw("Mouse Y") / 10f,
                0f);
        }
    }

    void RotateCamera()
    {
        if(Input.GetMouseButton(1))
        {
            transform.Rotate(Input.GetAxisRaw("Mouse Y") / 10f,
                Input.GetAxisRaw("Mouse X") / 10f,
                0f);
        }
    }

    void zoomCamera()
    {

        mainCamera.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));
        if (mainCamera.fieldOfView < 10)
            mainCamera.fieldOfView = 10;
        if (mainCamera.fieldOfView > 150)
            mainCamera.fieldOfView = 150;

       
    }
}
