using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControls : ParentControls
{
    // make it so ghost is controlled as first entity
    private void Start()
    {
        inControl = true;
    }


    // makes it so ghost can fly and move as well
    protected override void MoveEntity()
    {
        if (inControl)
        {
            // Makes a vector 3 based on the input and speed, then moves the entity to that position
            Vector3 move = mainControls.Main.Move.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;

            // Separate rotation and movement values
            Vector3 forwardBack = move.z * transform.forward;
            float leftRight = move.x;

            // Change character rotation
            //ChangeRotation(leftRight);

            // fly with addition 2 controls
            Vector3 fly = mainControls.Ghost.Fly.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;

            // move player
            if (forwardBack != Vector3.zero || fly != Vector3.zero)
            {
                rb.MovePosition(fly + forwardBack + transform.position);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }


    // possesses target in range
    protected override void Possession()
    {
        // if ability is activated and ghost in control
        if (inControl && mainControls.Main.Ability.triggered)
        {
            // checks for any possible possessable objects and possesses one if length is > 0
            Collider[] possessions = Physics.OverlapBox(transform.position, new Vector3(1, 1, 1), Quaternion.identity, LayerMask.GetMask("Possess", "PossessGrab"));
            if (possessions.Length > 0)
            {
                // move ghost to above the possessed object, make the ghost its child, then switch controls, and change camera control
                Collider entity = possessions[0];
                transform.position = entity.transform.position + new Vector3(0, 2, 0);
                transform.forward = entity.transform.forward;
                transform.parent = entity.transform;
                entity.GetComponent<ParentControls>().SetControl(true);
                CameraShift(entity.transform);
                SetControl(false);
                gameObject.SetActive(false);
            }
        }
    }
}
