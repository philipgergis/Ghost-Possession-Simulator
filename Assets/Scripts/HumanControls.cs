using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControls : ParentControls
{
    Inventory inv;

    private void Start()
    {
        inv = GetComponent<Inventory>();
    }

    protected override void StartAbility()
    {
        if(mainControls.Main.Ability.triggered)
        {
            GrabOrInteract();
        }
    }

    private void GrabOrInteract()
    {
        Collider[] grabs = Physics.OverlapBox(transform.position + transform.forward, new Vector3(2, 2, 2), Quaternion.identity, LayerMask.GetMask("Grab", "PossessGrab"));
        if (grabs.Length > 0)
        {
            inv.AddItem(grabs[0].gameObject);
        }


    }
}
