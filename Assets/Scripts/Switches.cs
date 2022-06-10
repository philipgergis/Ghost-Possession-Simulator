using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    // button object
    [SerializeField] private Transform button;

    // button adjustment value
    [SerializeField] protected float buttonAdjustment = 0.01f;

    // determines if the switch is on or not
    protected bool on = false;

    // when an object is on the switch it stays on
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Possess" || other.tag == "Human" )
        {
            SwitchActivate();
        }
        
    }

    // when a player leaves the switch it turns off
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Possess" || other.tag == "Human" )
        {
            SwitchDeactivate();
        }
    }

    // returns if switch is on or off
    public bool GetStatus()
    {
        return on;
    }

    // adjusts button position and makes switch true
    protected virtual void SwitchActivate()
    {
        SwitchMovement(-buttonAdjustment);
        on = true;
    }

    // adjusts button position and makes switch false
    protected virtual void SwitchDeactivate()
    {
        SwitchMovement(buttonAdjustment);
        on = false;
    }

    // moves switch button up or down
    protected void SwitchMovement(float upDown)
    {
        button.position = new Vector3(0,upDown,0) + button.position;
    }


}
