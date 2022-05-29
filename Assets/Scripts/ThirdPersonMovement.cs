using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : ParentControls
{
    public CharacterController controller;
    public Transform cam;

    //public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float leftRight = Input.GetAxisRaw("Horizontal");
        float forwardBackward = Input.GetAxisRaw("Vertical");
        
        Vector3 fly = mainControls.Ghost.Fly.ReadValue<Vector3>();
        float upDown = fly.y;

        Vector3 direction = new Vector3(leftRight, upDown, forwardBackward).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            
            //targetAngle needs to be + 90 degrees because for some reason the player model is always 90 degrees off
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle + 90f, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            if (direction.x == 0 && direction.z == 0)
            {
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(0, upDown, 0);
                controller.Move(moveDir.normalized * 2f * Time.fixedDeltaTime);
            }
            else
            {
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(0, upDown, 1);
                controller.Move(moveDir.normalized * 2f * Time.fixedDeltaTime);
            }
        }
    }
}
