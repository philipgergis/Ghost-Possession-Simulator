using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    // object to follow
    [SerializeField] private Transform tracking;

    // how far up the camera will be from the object
    [SerializeField] private float height;

    // how far behind the camera will be from the object
    [SerializeField] private float offset;

    // the angle at which the camera is looking down at the object from 0-90 degrees
    [SerializeField][Range(0, 90)] private float tilt;

    private void FixedUpdate()
    {
        // make camera face the same way as the player
        transform.rotation = tracking.transform.rotation;

        // make camera tilt downards to face the player
        transform.Rotate(new Vector3(tilt, 0, 0));

        // move the camera behind the player
        transform.position = new Vector3(-offset * tracking.transform.forward.x, height, -offset * tracking.transform.forward.z) + tracking.transform.position;
    }


    // change entity camera is following
    public void ChangeFocus(Transform newObject, float newHeight, float newOffset, float newTilt)
    {
        tracking = newObject;
        height = newHeight;
        offset = newOffset;
        tilt = newTilt;
    }
}
