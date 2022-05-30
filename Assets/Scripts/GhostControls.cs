using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControls : ParentControls
{
    //[SerializeField] protected CharacterController controller;

    // make it so ghost is controlled as first entity
    private void Start()
    {
        inControl = true;
    }

    // Update is called once per frame
    protected override void MoveEntity()
    {
        if(inControl)
        {
            float leftRight = mainControls.Main.Move.ReadValue<Vector3>().x; 
            float forwardBackward = mainControls.Main.Move.ReadValue<Vector3>().z; 
            float upDown = mainControls.Ghost.Fly.ReadValue<Vector3>().y; 

            Vector3 direction = new Vector3(leftRight, upDown, forwardBackward).normalized;
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                //targetAngle needs to be + 90 degrees because for some reason the player model is always 90 degrees off
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle + 90f, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                if(upDown != 0)
                {
                    rb.MovePosition(transform.position + new Vector3(0, upDown * speed * Time.fixedDeltaTime, 0));
                }
                else
                {
                    rb.MovePosition(transform.position + -transform.right * speed * Time.fixedDeltaTime);
                }
                
                //if (direction.x == 0 && direction.z == 0)
                //{
                //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(0, upDown, 0);
                //    rb.MovePosition(moveDir.normalized * 2f * Time.fixedDeltaTime);
                //}
                //else
                //{
                //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * new Vector3(0, upDown, 1);
                //    rb.MovePosition(moveDir.normalized * 2f * Time.fixedDeltaTime);
                //}
            }
        }
    }

    // possesses target in range
    protected override void Possession()
    {
        // if ability is activated and ghost in control
        if (inControl && mainControls.Ghost.Possess.triggered)
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
