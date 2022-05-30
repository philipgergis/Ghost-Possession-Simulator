using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControls : ParentControls
{
    // inventory of the player
    private Inventory inv;

    // get inventory of player
    private void Start()
    {
        inv = GetComponent<Inventory>();
    }

    // Ability to call for special ability
    protected override void StartAbility()
    {
        if(mainControls.Ghost.Ability.triggered && inControl)
        {
            GrabOrInteract();
        }
    }

    // Determines to grab or interact with an object
    private void GrabOrInteract()
    {
        // Gets object in an area, if they are grabbable it grabs the first one from the list
        Collider[] grabs = Physics.OverlapBox(transform.position + transform.forward, new Vector3(2, 2, 2), Quaternion.identity, LayerMask.GetMask("Grab", "PossessGrab"));

        // gets a list of doors in the area, and interacts with the first one from the list
        Collider[] doors = Physics.OverlapBox(transform.position + transform.forward, new Vector3(2, 2, 2), Quaternion.identity, LayerMask.GetMask("Door"));


        if (grabs.Length > 0 && inv.RoomAvailable())
        {
            inv.AddItem(grabs[0].gameObject);
        }
        else if (doors.Length > 0)
        {
            foreach (Collider col in doors)
            {
                DoorInteract door = col.GetComponent<DoorInteract>();
                door.Interaction(gameObject);
            }  
        }
    }
}
