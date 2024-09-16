using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] private float _speed;
    private Vector3 move;
    public Transform mainCamera;

    void Start()
    {
        characterController = GetComponent<CharacterController>();        
    }

    void Update()
    {
        Move();        
    }

    void Move()
    {
        Vector3 forward = mainCamera.forward;
        Vector3 right = mainCamera.right;

        // karakter kamera hareketlerine g�re ileri-geri yapt�g� i�in 
        forward.y = 0f;
        right.y = 0f;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        move = (forward * vertical + right * horizontal).normalized;
        characterController.Move(move * _speed * Time.deltaTime);

        // karakter hareket etmeyi b�rakt�g�nda bakt�g� y�nde kalmas�n� saglar
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }        
    } 
}
