using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Used to show image in inventory
public class Grabbables : MonoBehaviour
{
    // Image texture
    [SerializeField] private Texture itemImage;

    // Returns image
    public Texture GetImage()
    {
        return itemImage;
    }
}
