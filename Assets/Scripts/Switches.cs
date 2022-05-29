using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    // determines if the switch is on or not
    private bool on = false;

    // when an object is on the switch it stays on
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Possess" || other.tag == "Human")
        {
            on = true;
        }
        
    }

    // when a player leaves the switch it turns off
    private void OnTriggerExit(Collider other)
    {
        on = false;
    }

    // returns if switch is on or off
    public bool GetStatus()
    {
        return on;
    }
}
