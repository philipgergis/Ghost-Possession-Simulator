using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseTrigger : MonoBehaviour
{
    private bool on = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Cheese")
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
