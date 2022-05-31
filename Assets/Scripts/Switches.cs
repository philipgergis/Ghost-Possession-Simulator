using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    // determines if the switch is on or not
    protected bool on = false;

    // when an object is on the switch it stays on
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Possess" || other.tag == "Human")
        {
            SwitchActivate();
        }
        
    }

    // when a player leaves the switch it turns off
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Possess" || other.tag == "Human")
        {
            SwitchDeactivate();
        }
    }

    // returns if switch is on or off
    public bool GetStatus()
    {
        return on;
    }

    protected virtual void SwitchActivate()
    {
        on = true;
    }

    protected virtual void SwitchDeactivate()
    {
        on = false;
    }


}
