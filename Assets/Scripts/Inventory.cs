using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Inventory holds up to 5 items
    [SerializeField] int maxItems = 5;

    // Inventory child
    [SerializeField] Transform inv;

    // Adjustment for where to keep object at
    [SerializeField] Vector3 adjustment;

    // current index in inventory
    private int currentIndex = 0;

    // Checks if full capacity is reached
    public bool RoomAvailable()
    {
        return inv.childCount < maxItems;
    }


    // Add item to inventory
    public void AddItem(GameObject obj)
    {
        if(inv.childCount < maxItems)
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
        if(FindItem(obj))
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

    public int GetItem()
    {
        return currentIndex;
    }
}
