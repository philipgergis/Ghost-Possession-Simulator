using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbables : MonoBehaviour
{
    [SerializeField] private Texture itemImage;

    public Texture GetImage()
    {
        return itemImage;
    }
}
