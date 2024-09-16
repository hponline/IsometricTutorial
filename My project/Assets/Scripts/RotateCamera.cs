using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

   CinemachineVirtualCamera virtualCamera;
    [SerializeField]
    private float
        currentYRotation,
        zoomSpeed = 4f, 
        minFOV = 8f, 
        maxFOV = 30f,
        smooth= 5.0f;

    private Quaternion targetRotation;
    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.m_Lens.OrthographicSize = 10.0f;
        //targetRotation = transform.rotation;
    }

    void Update()
    {
        MouseScroll();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CameraRotate(90);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CameraRotate(-90);
        }
        // Kamera Hareketlerini yumusatma
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smooth * Time.deltaTime);
    }

    void CameraRotate(float angle)
    {
        currentYRotation += angle;
        targetRotation = Quaternion.Euler(30, currentYRotation, 0);       
    }

    void MouseScroll()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        virtualCamera.m_Lens.OrthographicSize -= scrollInput * zoomSpeed;
        virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp (virtualCamera.m_Lens.OrthographicSize,minFOV,maxFOV);
    }
}
