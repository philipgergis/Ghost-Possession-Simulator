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

    protected override void MoveEntity()
    {
        if (inControl)
        {
            Vector3 move = mainControls.Main.Move.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;
            Vector3 fly = mainControls.Ghost.Fly.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;
            rb.MovePosition(fly + move + transform.position);
        }
    }

    protected override void Possession()
    {
        if (inControl && mainControls.Main.Ability.triggered)
        {
            Collider[] possessions = Physics.OverlapBox(transform.position, new Vector3(3, 3, 3), Quaternion.identity, LayerMask.GetMask("Possess"));
            if (possessions.Length > 0)
            {
                transform.position = possessions[0].transform.position + new Vector3(0, 2, 0);
                transform.parent = possessions[0].transform;
                possessions[0].GetComponent<ParentControls>().SetControl(true);
                SetControl(false);
                gameObject.SetActive(false);
            }
        }
    }
}
