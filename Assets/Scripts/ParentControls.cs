using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentControls : MonoBehaviour
{
    // protected camera values, first is height, second is offset, third is tilt
    [SerializeField] protected float[] cameraValues = new float[3];

    // boolean to check if player is controlling entity
    protected bool inControl = false;

    // Input Actions for controls
    protected MainControls mainControls;
    protected Rigidbody rb;

    // Speed for movement
    [SerializeField] protected float speed = 5;

    // Speed for rotation
    [SerializeField] protected float rotationSpeed = 1800;


    // Initiate parentControls
    protected virtual void Awake()
    {
        mainControls = new MainControls();
        rb = GetComponent<Rigidbody>();
    }


    // Enable parentControls
    private void OnEnable()
    {
        mainControls.Enable();
    }


    // disable parentControls
    private void OnDisable()
    {
        mainControls.Disable();
    }


    // function used to move the entity based on wasd input
    // moves through rigidbody by setting velocity
    protected virtual void MoveEntity()
    {
        if(inControl)
        {
            // Makes a vector 3 based on the input and speed, then moves the entity to that position
            Vector3 move = mainControls.Main.Move.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;

            // Separate rotation and movement values
            Vector3 forwardBack = move.z * transform.forward;
            float leftRight = move.x;

            // Changes character rotation
            ChangeRotation(leftRight);

            // Move character
            rb.MovePosition(forwardBack + transform.position);
        }
    }


    // used to change inControl
    public void SetControl(bool control)
    {
        inControl = control;
    }


    // if object is possessed and nothing is blocking the ghost, the ghost unpossesses the entity
    protected virtual void Possession()
    {
        // ghost variable
        Transform ghost = null;

        // looks for a ghost in the child objects
        foreach (Transform child in transform)
        {
            if (child.tag == "Ghost")
            {
                ghost = child;
                break;
            }
        }

        // if entity is in control, the possess button is pressed, and the ghost is a child, unpossess the target
        if (inControl && mainControls.Main.Possess.triggered && ghost != null)
        {
            // checks for objects the ghost cannot spawn over
            Collider[] obstacles = Physics.OverlapBox(ghost.position, new Vector3(1, 1, 1), Quaternion.identity, LayerMask.GetMask("Anti-Ghost"));

            // if no objects blocking the way, unposssess target and change the camera
            if(obstacles.Length == 0)
            {
                ghost.gameObject.SetActive(true);
                ghost.GetComponent<ParentControls>().SetControl(true);
                ghost.transform.parent = null;
                CameraShift(ghost);
                SetControl(false);
            } 
        }   
    }


    // change character rotation
    protected void ChangeRotation(float move)
    {
        // make player face direction it is going in
        if (move != 0)
        {
            transform.Rotate(0, move * rotationSpeed * Time.fixedDeltaTime, 0);
        }
    }


    // makes camera follow right entity
    protected void CameraShift(Transform newObject)
    {
        GameObject mc = GameObject.FindGameObjectWithTag("MainCamera");
        float[] cv = newObject.GetComponent<ParentControls>().GetCameraValues();
        mc.GetComponent<CameraTrack>().ChangeFocus(newObject, cv[0], cv[1], cv[2]);
    }

    protected float[] GetCameraValues()
    {
        return cameraValues;
    }

    protected virtual void StartAbility()
    {

    }


    // handles movement of the player
    protected virtual void FixedUpdate()
    {
        MoveEntity();
    }


    // handles other controls
    protected void Update()
    {
        StartAbility();
        Possession();
    }

    

}
