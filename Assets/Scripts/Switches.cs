using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    private bool on = false;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Possess" || other.tag == "Human")
        {
            on = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        on = false;
    }

    public bool GetStatus()
    {
        return on;
    }
}
