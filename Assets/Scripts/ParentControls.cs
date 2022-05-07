using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentControls : MonoBehaviour
{
    // boolean to check if player is controlling entity
    protected bool inControl = false;

    // Input Actions for controls
    protected MainControls mainControls;
    protected Rigidbody rb;

    // Speed for movement
    [SerializeField] protected float speed;


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
            rb.MovePosition(move + transform.position);
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
            Collider[] obstacles = Physics.OverlapBox(ghost.position, new Vector3(2, 2, 2), Quaternion.identity, LayerMask.GetMask("Anti-Ghost"));

            // if no objects blocking the way, unposssess target
            if(obstacles.Length == 0)
            {
                ghost.gameObject.SetActive(true);
                ghost.GetComponent<ParentControls>().SetControl(true);
                ghost.transform.parent = null;
                SetControl(false);
            } 
        }   
    }

    // handles movement of the player
    protected virtual void FixedUpdate()
    {
        MoveEntity();
    }

    // handles other controls
    protected void Update()
    {
        Possession();
    }

}
