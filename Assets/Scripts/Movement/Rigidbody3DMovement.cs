using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigidbody3DMovement : MonoBehaviour
{
    private Vector2 movementInput;

    private void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //Vector3 movement = Vector3.Normalize(transform.right * movementInput.x + transform.forward * z);

    }
}
