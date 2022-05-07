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
            Vector3 move = mainControls.Main.Move.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;
            rb.MovePosition(move + transform.position);
        }
    }

    public void SetControl(bool control)
    {
        inControl = control;
    }

    protected virtual void Possession()
    {
        if (inControl && mainControls.Main.Possess.triggered)
        {
            foreach(Transform child in transform)
            {
                if(child.tag == "Ghost")
                {
                    child.gameObject.SetActive(true);
                    child.GetComponent<ParentControls>().SetControl(true);
                    child.transform.parent = null;
                    SetControl(false);
                    break;
                }
            }
        }   
    }

    // handles movement of the player
    protected virtual void FixedUpdate()
    {
        MoveEntity();
    }

    protected void Update()
    {
        Possession();
    }

}
