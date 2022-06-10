using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControls : ParentControls
{
    // sound audio
    private AudioSource ghostAudio;

    // no flight bool
    [SerializeField] private bool flight = true;

    // needed for sound
    protected override void Awake()
    {
        base.Awake();
        ghostAudio = GetComponent<AudioSource>();
    }

    // make it so ghost is controlled as first entity
    private void Start()
    {
        inControl = true;
    }


    // Moves entity using three vector inputs
    protected override void MoveEntity()
    {
        // check for
        if(inControl)
        {
            // vector3 inputs for each axis
            float leftRight = mainControls.Main.Move.ReadValue<Vector3>().x; 
            float forwardBackward = mainControls.Main.Move.ReadValue<Vector3>().z; 
            float upDown = mainControls.Ghost.Fly.ReadValue<Vector3>().y; 

            // direction of movement based on three vector3 inputs
            Vector3 direction = new Vector3(leftRight, upDown, forwardBackward).normalized;

            // if direction is not 0, then executemovement
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                //targetAngle needs to be + 90 degrees because for some reason the player model is always 90 degrees off
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle + 90f, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                // cant fly and move at the same time
                if(upDown != 0)
                {
                    if(flight)
                    {
                        rb.MovePosition(transform.position + new Vector3(0, upDown * speed * Time.fixedDeltaTime, 0));
                    }
                }
                else
                {
                    if(flight)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                        rb.MovePosition(transform.position + -transform.right * speed * Time.fixedDeltaTime);
                    }
                    else
                    {
                        rb.MovePosition(transform.position + -transform.right * speed * Time.fixedDeltaTime);
                    }
                    
                }
                
            }

            // when there is no input, ensure ghost is not moving
            else
            {
                if(flight)
                {
                    rb.velocity = Vector3.zero;
                }
                else
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                }
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
            Collider[] possessions = Physics.OverlapSphere(transform.position, radiusDetect, mask);
            if (possessions.Length > 0 && (!possessions[0].GetComponent<ParentControls>().TameType() || possessions[0].GetComponentInChildren<TameableBehavior>().CheckTame()))
            {
                // play possession sfx
                AudioSource.PlayClipAtPoint(ghostAudio.clip, transform.position, 2.0f);   // for some reason ghostAudio.Play() doesnt work

                // move ghost to above the possessed object, make the ghost its child, then switch controls, and change camera control
                Collider entity = possessions[0];
                transform.position = entity.transform.position + new Vector3(0, 2, 0);
                transform.parent = entity.transform;
                entity.GetComponent<ParentControls>().SetControl(true);

                // if possessed object is a human, use its CameraLookAt transform instead of the human's transform (bc it's too low)
                CameraShift(entity.GetComponent<ParentControls>().GetCameraLookAt());

                // update inventory if inventory item
                InventoryControls invCheck = entity.GetComponent<InventoryControls>();
                if (invCheck != null)
                {
                    invCheck.ShowAccessibleSlots(false);
                    invCheck.ShowItemImages();
                }

                // turn off ghost
                SetControl(false);
                gameObject.SetActive(false);
            }
        }
    }
}
