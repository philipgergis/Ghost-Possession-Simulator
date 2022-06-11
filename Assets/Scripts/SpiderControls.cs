using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderControls : ParentControls
{

    [SerializeField] Transform wallDetector;
    [SerializeField] LayerMask maskClimb;

    protected override void MoveEntity()
    {
        if (inControl)
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

                if (Physics.CheckSphere(wallDetector.position, radiusDetect, maskClimb) && forwardBackward > 0)
                {
                    rb.velocity = Vector3.up * speed;

                }
                else
                {
                    rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
                }
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }
    }
    
}
