using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : Interact
{
    // Decides if this door is the final door in the level
    [SerializeField] private bool finalDoor;
    [SerializeField] private GameObject endMenu;

    // Key needed to unlock the door
    [SerializeField] private GameObject key;

    // interactions involving unlocking doors
    public override void Interaction(GameObject obj)
    {
        // Checks if the object is the right type to unlock the door
        if(obj.tag == "Human")
        {

            // Checks the inventory of the player to see if the lpayer has the key
            InventoryControls inv = obj.GetComponent<InventoryControls>();
            if(inv.GetCurrentItem() == key && inv.GetCurrentItem().GetInstanceID() == key.GetInstanceID())
            {
                // delete key if the key is the right one for the door
                inv.DeleteItem(key);

                // ends game if door is final door
                if(finalDoor)
                {
                    endMenu.SetActive(true);
                }

                // play sfx for opening door
                if (TryGetComponent<AudioSource>(out AudioSource doorAudio))
                {
                    AudioSource.PlayClipAtPoint(doorAudio.clip, transform.position, 2.0f);
                }

                // destroys door to unlock it
                Destroy(gameObject);
            }
        }
    }
}
