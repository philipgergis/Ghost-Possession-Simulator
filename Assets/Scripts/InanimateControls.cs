using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InanimateControls : ParentControls
{
    [SerializeField] private float maxTime;
    private float currentTime = 0;


    protected override void MoveEntity()
    {
        if (inControl && currentTime <= 0)
        {
            float leftRight = mainControls.Main.Move.ReadValue<Vector3>().x;
            float forwardBackward = mainControls.Main.Move.ReadValue<Vector3>().z;

            Vector3 direction = new Vector3(leftRight, 0f, forwardBackward).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                //targetAngle needs to be + 90 degrees because for some reason the player model is always 90 degrees off
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle + adjustmentAngle, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                //rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
                rb.AddForce(transform.position + transform.forward * speed);
                currentTime = maxTime;
            }
        }
        else
        {
            currentTime--;
        }
    }
}
