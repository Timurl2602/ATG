using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class PlayerController : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private bool RotateTowardMouse;

    [SerializeField] 
    private float movementSpeed;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;
    [SerializeField]
    private float RotationSpeed;
    [SerializeField] 
    private float stamina;
    public float Stamina
    {
        get { return stamina; }
    }
    [SerializeField] 
    private float maxStamina;
    public float MaxStamina
    {
        get { return maxStamina; }
    }
    [SerializeField] 
    private float dValue;

    [SerializeField]
    private Camera Camera;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    private void Start()
    {
        stamina = maxStamina;
        movementSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);

        if (!RotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 0)
        {
            movementSpeed = sprintSpeed;
            DecreaseStamina();
        }
        else if (stamina != maxStamina && stamina <= maxStamina)
        {
            IncreaseStamina();
            movementSpeed = walkSpeed;
        }


    }

    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = movementSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }

    private void DecreaseStamina()
    {
        if (stamina != 0)
        {
            stamina -= dValue * Time.deltaTime;
        }
    }
    
    private void IncreaseStamina()
    {
        stamina += dValue * Time.deltaTime;
    }
}