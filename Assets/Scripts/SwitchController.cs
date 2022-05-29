using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // gets the switches needed to activate a certain event
    [SerializeField] private Switches[] switches;

    // item the switches release
    [SerializeField] private GameObject item;


    // activates item if switches are all on
    void Update()
    {
        if(CheckAllSwitches())
        {
            item.SetActive(true);
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
