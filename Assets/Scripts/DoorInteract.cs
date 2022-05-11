using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interact
{
    [SerializeField] private bool finalDoor;

    [SerializeField] private GameObject key;
    public override void Interaction(GameObject obj)
    {
        if(obj.tag == "Human")
        {
            Inventory inv = obj.GetComponent<Inventory>();
            if(inv.FindItem(key))
            {
                inv.DeleteItem(key);
                if(finalDoor)
                {
                    Debug.Log("Level Complete!");
                }
                Destroy(gameObject);
            }
        }
    }
}
