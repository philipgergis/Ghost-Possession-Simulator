using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interact
{
    [SerializeField] private GameObject key;
    public override void Interaction(GameObject obj)
    {
        if(obj.tag == "Human")
        {
            Inventory inv = obj.GetComponent<Inventory>();
            if(inv.FindItem(key))
            {
                inv.DeleteItem(key);
                Destroy(gameObject);
            }
        }
    }
}
