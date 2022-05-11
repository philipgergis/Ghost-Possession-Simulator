using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private Switches[] switches;

    [SerializeField] private GameObject item;

    // Update is called once per frame
    void Update()
    {
        if(CheckAllSwitches())
        {
            item.SetActive(true);
        }
    }

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
