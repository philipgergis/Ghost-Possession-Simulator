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

    protected override void Possession()
    {
        // if entity is in control, the possess button is pressed, and the ghost is a child, unpossess the target
        if (inControl && mainControls.Main.Possess.triggered)
        {
            // ghost variable
            Transform ghost = null;

            // looks for a ghost in the child objects
            foreach (Transform child in transform)
            {
                if (child.tag == "Ghost")
                {
                    ghost = child;
                    break;
                }
            }
            if (ghost != null)
            {
                // checks for objects the ghost cannot spawn over
                Collider[] obstacles = Physics.OverlapSphere(transform.position + Vector3.up, radiusDetect, mask);

                // if no objects blocking the way, unposssess target and change the camera
                // makes it so it checks above inanimate object for obstacles instead of the ghost position to account for object rotating while moving
                if (obstacles.Length == 0)
                {
                    ghost.gameObject.SetActive(true);
                    ghost.GetComponent<ParentControls>().SetControl(true);
                    ghost.transform.parent = null;
                    ghost.transform.position = transform.position + Vector3.up;
                    ghost.rotation = new Quaternion(0, transform.rotation.y, 0, 0);
                    CameraShift(ghost);
                    SetControl(false);
                }
            }
        }
    }
}
