using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public static HotbarManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateSlot(int index, bool selected, int element )
    {
        transform.GetChild(index).GetChild(element).gameObject.SetActive(selected);
    }

    
}
