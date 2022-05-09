using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField] private Transform tracking;

    [SerializeField] private Vector3 distance;

    private void FixedUpdate()
    {
        transform.position = distance + tracking.position;
    }

    public void ChangeFocus(Transform newObject)
    {
        tracking = newObject;
    }
}
