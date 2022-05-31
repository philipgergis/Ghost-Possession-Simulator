using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void SetSlotImage(int index, Texture txt)
    {
        transform.GetChild(index).GetChild(3).GetComponent<RawImage>().texture = txt;
    }

    
}
