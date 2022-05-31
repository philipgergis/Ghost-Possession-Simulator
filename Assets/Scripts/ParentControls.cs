using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentControls : MonoBehaviour
{
    protected Transform cam;

    //public float speed = 6f;
    [SerializeField] protected float turnSmoothTime = 0.1f;
    [SerializeField] protected float turnSmoothVelocity;
    [SerializeField] protected float adjustmentAngle;


    // boolean to check if player is controlling entity
    protected bool inControl = false;

    // Input Actions for controls
    protected MainControls mainControls;
    protected Rigidbody rb;

    // Speed for movement
    [SerializeField] protected float speed = 5;


    // Initiate parentControls
    protected virtual void Awake()
    {
        mainControls = new MainControls();
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
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
            float leftRight = mainControls.Main.Move.ReadValue<Vector3>().x;
            float forwardBackward = mainControls.Main.Move.ReadValue<Vector3>().z;

            Vector3 direction = new Vector3(leftRight, 0f, forwardBackward).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

                //targetAngle needs to be + 90 degrees because for some reason the player model is always 90 degrees off
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle + adjustmentAngle, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                rb.MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
            }
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
        if (inControl && mainControls.Main.Possess.triggered && ghost != null && rb.velocity == Vector3.zero)
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


    


    // makes camera follow right entity
    protected void CameraShift(Transform newObject)
    {
        GameObject mc = GameObject.FindGameObjectWithTag("TPC");
        CinemachineFreeLook tpc = mc.GetComponent<CinemachineFreeLook>();
        tpc.Follow = newObject;
        tpc.LookAt = newObject;
    }

    

    // used when entities have special abilities
    protected virtual void StartAbility()
    {

    }


    // handles movement of the player
    protected virtual void FixedUpdate()
    {
        MoveEntity();
    }


    // handles other controls
    protected virtual void Update()
    {
        StartAbility();
        Possession();
    }

    

}
