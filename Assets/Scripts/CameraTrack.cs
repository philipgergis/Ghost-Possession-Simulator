using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField] private Transform tracking;

    [SerializeField] private float height;

    [SerializeField] private float offset;

    [SerializeField][Range(0, 90)] private float tilt;

    private void FixedUpdate()
    {
        transform.rotation = tracking.transform.rotation;
        transform.Rotate(new Vector3(tilt, 0, 0));

        transform.position = new Vector3(-offset * tracking.transform.forward.x, height, -offset * tracking.transform.forward.z) + tracking.transform.position;
        Debug.Log(tracking.transform.forward);
    }

    public void ChangeFocus(Transform newObject)
    {
        tracking = newObject;
    }
}
