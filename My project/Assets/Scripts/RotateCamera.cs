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
        maxFOV = 30f;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.m_Lens.OrthographicSize = 10.0f;
    }

    void Update()
    {
        MouseScroll();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CameraSetting(90);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CameraSetting(-90);
        }
    }

    void CameraSetting(float angle)
    {
        currentYRotation += angle;
        transform.rotation = Quaternion.Euler(30, currentYRotation, 0);   
    }

    void MouseScroll()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        virtualCamera.m_Lens.OrthographicSize -= scrollInput * zoomSpeed;
        virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp (virtualCamera.m_Lens.OrthographicSize,minFOV,maxFOV);
    }
}
