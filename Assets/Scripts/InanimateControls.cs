using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InanimateControls : ParentControls
{
    // time it takes to move again
    [SerializeField] private float maxTime;

    // time remaining to move again
    private float currentTime = 0;


    protected override void MoveEntity()
    {
        // only move if the current time has run out
        if (inControl && currentTime <= 0)
        {
            float leftRight = mainControls.Main.Move.ReadValue<Vector3>().x;
            float forwardBackward = mainControls.Main.Move.ReadValue<Vector3>().z;

            Vector3 direction = new Vector3(leftRight, 0f, forwardBackward).normalized;

            if (direction.magnitude >= 0.1f)
            {
                rb.AddForce(direction * speed);
                currentTime = maxTime;
            }
        }
        else
        {
            // subtract from current time if tried to move but cannot
            currentTime--;
        }
    }
}
