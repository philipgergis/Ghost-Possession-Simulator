using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Hotbar inventory for entities
public class HotbarManager : MonoBehaviour
{
    // Singleton
    public static HotbarManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // updates a slot in the hotbar
    // index refers to the slot it is selecting
    // selected refers to whether you should turn on or off an element of the slot
    // element refers to the different parts of a slot
    //      0 is the slash, 2 is the selection border, 3 is the image
    public void UpdateSlot(int index, bool selected, int element )
    {
        transform.GetChild(index).GetChild(element).gameObject.SetActive(selected);
    }

    // gets a slot and sets its image to a new image
    public void SetSlotImage(int index, Texture txt)
    {
        transform.GetChild(index).GetChild(3).GetComponent<RawImage>().texture = txt;
    }

    
}
