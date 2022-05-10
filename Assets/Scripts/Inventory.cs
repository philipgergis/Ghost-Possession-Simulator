using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Inventory holds up to 5 items
    private int total = 0;
    [SerializeField] int maxItems = 5;

    // Inventory child
    [SerializeField] Transform inv;


    // Add item to inventory
    public void addItem(GameObject obj)
    {
        if(total < maxItems)
        {
            total++;
            obj.transform.parent = inv;
            obj.transform.position = transform.position + transform.forward * 1;
            obj.SetActive(false);
        }
    }

    // Delete item from inventory
    // Add item to inventory
    public void deleteItem(GameObject obj)
    {
        foreach(Transform child in inv)
        {
            if(child == obj)
            {
                Destroy(obj);
                total--;
                break;
            }
        }
    }


    // drop item
    public void dropItem(int index)
    {
        Transform child = inv.GetChild(index);
        child.parent = null;
        total--;
        child.gameObject.SetActive(true);
    }

    public bool findItem(GameObject obj)
    {
        foreach (Transform child in inv)
        {
            if (child == obj)
            {
                return true;
            }
        }
        return false;
    }
}
