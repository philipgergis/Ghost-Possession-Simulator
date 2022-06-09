using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // gets the switches needed to activate a certain event
    [SerializeField] private Switches[] switches;

    // item the switches release
    [SerializeField] private GameObject item;

    // makes sure to only set item active once


    // activates item if switches are all on
    void Update()
    {
        if (CheckAllSwitches())
        {
            // add item = null so switch doesnt activate item when in entity inventory
            item.SetActive(true);
            item = null;
            gameObject.SetActive(false);
        }
    }

    // iterates through switches to see if they are all on
    private bool CheckAllSwitches()
    {
        foreach (Switches s in switches)
        {
            if(!s.GetStatus())
            {
                return false;
            }
        }
        return true;
    }
}
