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
            // move with wasd
            Vector3 move = mainControls.Main.Move.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;

            // fly with q and e
            Vector3 fly = mainControls.Ghost.Fly.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;

            // move to new position made from fly and move
            rb.MovePosition(fly + move + transform.position);
        }
    }

    // possesses target in range
    protected override void Possession()
    {
        // if ability is activated and ghost in control
        if (inControl && mainControls.Main.Ability.triggered)
        {
            // checks for any possible possessable objects and possesses one if length is > 0
            Collider[] possessions = Physics.OverlapBox(transform.position, new Vector3(3, 3, 3), Quaternion.identity, LayerMask.GetMask("Possess"));
            if (possessions.Length > 0)
            {
                // move ghost to above the possessed object, make the ghost its child, then switch controls
                transform.position = possessions[0].transform.position + new Vector3(0, 2, 0);
                transform.parent = possessions[0].transform;
                possessions[0].GetComponent<ParentControls>().SetControl(true);
                SetControl(false);
                gameObject.SetActive(false);
            }
        }
    }
}
