using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControls : ParentControls
{
    // inventory of the player
    protected Inventory inv;

    protected virtual void Start()
    {
        inv = GetComponent<Inventory>();
    }

    protected void DropObject()
    {
        inv.DropItem(inv.GetItem());
    }

    protected void GrabObject()
    {
        // Gets object in an area, if they are grabbable it grabs the first one from the list
        Collider[] grabs = Physics.OverlapBox(transform.position + transform.forward, new Vector3(2, 2, 2), Quaternion.identity, LayerMask.GetMask("Grab", "PossessGrab"));

        if (grabs.Length > 0 && inv.RoomAvailable())
        {
            inv.AddItem(grabs[0].gameObject);
        }
    }

    // Ability to call for special ability
    protected override void StartAbility()
    {
        if (mainControls.Main.Ability.triggered && inControl)
        {
            GrabObject();
        }
        else if(mainControls.Main.Drop.triggered && inControl)
        {
            DropObject();
        }
    }
}
