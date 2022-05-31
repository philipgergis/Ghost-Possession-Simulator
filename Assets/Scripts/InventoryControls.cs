using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControls : ParentControls
{
    // Inventory holds up to 5 items
    [SerializeField] protected int maxItems = 5;

    // Inventory child
    [SerializeField] protected Transform inv;

    // Adjustment for where to keep object at
    [SerializeField] protected Vector3 adjustment;

    // current index in inventory
    protected int currentIndex = 0;

    // Checks if full capacity is reached
    public bool RoomAvailable()
    {
        return inv.childCount < maxItems;
    }


    // Add item to inventory
    public void AddItem(GameObject obj)
    {
        if (inv.childCount < maxItems)
        {
            obj.transform.parent = inv;
            obj.transform.position = transform.position + transform.forward + adjustment;
            obj.SetActive(false);
        }
    }

    // Delete item from inventory
    // Add item to inventory
    public void DeleteItem(GameObject obj)
    {
        if (FindItem(obj))
        {
            Destroy(obj);
        }
    }


    // drop item
    public void DropItem(int index)
    {

        
        Transform child = inv.GetChild(index);

        if (child != null && Physics.OverlapSphere(child.position, 0.5f).Length == 0)
        {
            child.parent = null;
            child.gameObject.SetActive(true);
        }
    }

    // checks if an item is in the inventory
    public bool FindItem(GameObject obj)
    {
        foreach (Transform child in inv)
        {
            if (child.gameObject == obj)
            {
                return true;
            }
        }
        return false;
    }


    protected virtual void Start()
    {
        
    }


    protected void GrabObject()
    {
        // Gets object in an area, if they are grabbable it grabs the first one from the list
        Collider[] grabs = Physics.OverlapBox(transform.position + transform.forward, new Vector3(2, 2, 2), Quaternion.identity, LayerMask.GetMask("Grab", "PossessGrab"));

        if (grabs.Length > 0 && RoomAvailable())
        {
            AddItem(grabs[0].gameObject);
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
            DropItem(currentIndex);
        }
    }
}
