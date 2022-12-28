using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class BasicPlaneMove : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private float speed = 1.0f;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        controller.SimpleMove(moveDirection * speed);
    }

    public void Move(InputAction.CallbackContext callback)
    {
        Vector2 inputValue = callback.ReadValue<Vector2>();
        Vector3 tmp = new Vector3(inputValue[0], 0, inputValue[1]);
        moveDirection = Quaternion.Euler(0, cameraTransform.localEulerAngles[1], 0) * tmp;
    }
}
